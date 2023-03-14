using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository _repository;

        public AgentService(IRepository repository)
            => 
            _repository = repository;

        public async Task<bool> ExistsById(string userId)
            => await
            _repository
            .All<Agent>()
            .AnyAsync(a => a.UserId == userId);

        public async Task<bool> UserWithPhoneExists(string phoneNumber)
            => await 
            _repository
            .All<Agent>()
            .AnyAsync(a => a.PhoneNumber == phoneNumber);

        public async Task<bool> UserHasRents(string userId)
            => await 
            _repository
            .All<House>()
            .AnyAsync(h => h.RenterId == userId);

        public async Task<int> GetAgentId(string userId)
            => (await
            _repository
            .All<Agent>()
            .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;

        public async Task Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await _repository.AddAsync(agent);
            await _repository.SaveChangesAsync();
        }

    }
}
