using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Exeptions;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository _repository;
        private readonly IGuard _guard;

        public HouseService(IRepository repository, IGuard guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<bool> CategoryExists(int categoryId)
            => await 
            _repository
           .AllReadonly<Category>()
           .AnyAsync(c => c.Id == categoryId);

        public async Task<int> Create(HouseFormModel model, int agentId)
        {
            var house = new House()
            {
                Title = model.Title,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                CategoryId = model.CategoryId,
                AgentId = agentId
            };

            await _repository.AddAsync(house);
            await _repository.SaveChangesAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseIndexModel>> LastThreeHouses()
            => await 
            _repository
            .AllReadonly<House>()
            .Where(h => !h.IsDeleted)
            .OrderByDescending(h => h.Id)
            .Take(3)
            .Select(h => new HouseIndexModel()
            {
                Id = h.Id,
                Title = h.Title,
                ImageUrl = h.ImageUrl
            })
            .ToListAsync();

        public async Task<IEnumerable<HouseCategoryModel>> AllCategoties()
            => await 
            _repository
            .AllReadonly<Category>()
            .OrderByDescending(c => c.Id)
            .Select(c => new HouseCategoryModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

        public async Task<HouseQueryServiceModel> All(
            string? category = null, 
            string? searchTerm = null, 
            HouseSorting houseSorting = HouseSorting.Newest, 
            int currentPage = 1, 
            int housesPerPage = 1)
        {
            var result = new HouseQueryServiceModel();
            var housesQuery = _repository
                .AllReadonly<House>()
                .Where(h => !h.IsDeleted);

            if (!string.IsNullOrEmpty(category))
            {
                housesQuery = housesQuery
                    .Where(h => h.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                housesQuery = housesQuery
                    .Where(h => EF.Functions.Like(h.Title.ToLower(), searchTerm) ||
                                EF.Functions.Like(h.Address.ToLower(), searchTerm) ||
                                EF.Functions.Like(h.Description.ToLower() , searchTerm));
            }

            if (houseSorting == HouseSorting.Price)
            {
                housesQuery = housesQuery.OrderBy(h => h.PricePerMonth);
            }
            else if (houseSorting == HouseSorting.NotRentedFirst)
            {
                housesQuery = housesQuery.OrderBy(h => h.RenterId);
            }
            else
            {
                housesQuery = housesQuery.OrderBy(h => h.Id);
            }

            result.Houses = await housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth
                })
                .ToListAsync();

            result.TotalHouseCount = await housesQuery.CountAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoryNames()
            =>
            await
            _repository
            .AllReadonly<Category>()
            .Select(c => c.Name)
            .ToListAsync();

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int agentId)
        {
            var houses = await _repository
                .AllReadonly<House>()
                .Where(h => !h.IsDeleted)
                .Where(h => h.AgentId == agentId)
                .ToListAsync();

            return ProjectToModel(houses);
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId)
        {
            var houses = await _repository
                .AllReadonly<House>()
                .Where(h => !h.IsDeleted)
                .Where(h => h.RenterId == userId)
                .ToListAsync();

            return ProjectToModel(houses);
        }

        public async Task<HouseDetailsViewModel> HouseDetailsById(int id)
            => await
            _repository
            .AllReadonly<House>()
            .Where(h => !h.IsDeleted)
            .Where(h => h.Id == id)
            .Select(h => new HouseDetailsViewModel()
            {
                Id = h.Id,
                Address = h.Address,
                Description = h.Description,
                Title = h.Title,
                ImageUrl = h.ImageUrl,
                IsRented = h.RenterId != null,
                Category = h.Category.Name,
                PricePerMonth = h.PricePerMonth,
                Agent = new AgentServiceModel()
                {
                    Email = h.Agent.User.Email,
                    PhoneNumber = h.Agent.PhoneNumber
                }
            })
            .FirstAsync();

        public async Task<bool> Exists(int id)
            => await
            _repository
            .AllReadonly<House>()
            .AnyAsync(h => h.Id == id && h.IsDeleted == true);

        private static List<HouseServiceModel> ProjectToModel(List<House> houses)
        {
            var resultHouses = houses
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null
                })
                .ToList();

            return resultHouses;
        }

        public async Task Edit(int houseId, HouseFormModel model)
        {
            var house = await _repository.GetByIdAsync<House>(houseId);

            house.Title = model.Title;
            house.Description = model.Description;
            house.Address = model.Address;
            house.ImageUrl = model.ImageUrl;
            house.CategoryId = model.CategoryId;
            house.PricePerMonth = model.PricePerMonth;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> HasAgentWithId(int houseId, string currentUserId)
        {
            bool result = false;
            var data = await _repository
                .AllReadonly<House>()
                .Where(h => !h.IsDeleted)
                .Where(h => h.Id == houseId)
                .Include(h => h.Agent)
                .FirstOrDefaultAsync();

            if (data?.Agent != null && data.Agent.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<int> GetHouseCategoryId(int houseId)
            => (await 
            _repository
            .GetByIdAsync<House>(houseId))
            .CategoryId;

        public async Task Delete(int houseId)
        {
            var house = await _repository.GetByIdAsync<House>(houseId);
            house.IsDeleted = true;
           
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> IsRented(int houseId)
        {
            bool result = false;
            var house = await _repository.GetByIdAsync<House>(houseId);
            _guard.AggainstNull(house, "House can not be found");
            if (house.RenterId != null)
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> IsRentedByUserId(int houseId, string userId)
        {
            bool result = false;
            var data = await _repository
                .AllReadonly<House>()
                .Where(h => !h.IsDeleted)
                .Where(h => h.Id == houseId)
                .FirstOrDefaultAsync();

            if (data != null && data.RenterId == userId)
            {
                result = true;
            }

            return result;
        }

        public async Task Rent(int houseId, string userId)
        {
            var house = await _repository.GetByIdAsync<House>(houseId);

            if (house != null && house.RenterId != null)
            {
                throw new ArgumentException("House is already rented");
            }

            _guard.AggainstNull(house, "House can not be found");
            house!.RenterId = userId;

            await _repository.SaveChangesAsync();
        }

        public async Task Leave(int houseId)
        {
            var house = await _repository.GetByIdAsync<House>(houseId);
            _guard.AggainstNull(house, "House can not be found");

            house.RenterId = null;

            await _repository.SaveChangesAsync();
        }
    }
}
