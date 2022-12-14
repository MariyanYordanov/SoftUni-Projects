using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts;

public interface IHouseService
{
    Task<bool> CategoryExists(int categoryId);

    Task<int> Create(HouseFormModel model, int agentId);

    Task<IEnumerable<HouseIndexModel>> LastThreeHouses();

    Task<IEnumerable<HouseCategoryModel>> AllCategoties();

    Task<HouseQueryServiceModel> All(
        string? category = null,
        string? searchTerm = null,
        HouseSorting houseSorting = HouseSorting.Newest,
        int currentPage = 1,
        int housesPerPage = 1);

    Task<IEnumerable<string>> AllCategoryNames();

    Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int agentId);

    Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId);

    Task<HouseDetailsViewModel> HouseDetailsById(int id);

    Task<bool> Exists(int id);

    Task Edit(int houseId, HouseFormModel model);

    Task<bool> HasAgentWithId(int houseId, string currentUserId);

    Task<int> GetHouseCategoryId(int houseId);

    Task Delete(int houseId);

    Task<bool> IsRented(int id);

    Task<bool> IsRentedByUserId(int houseId, string userId);

    Task Rent(int houseId, string userId);

    Task Leave(int houseId);
}
