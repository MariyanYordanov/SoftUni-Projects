using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts;

public interface IAgentService
{
    Task<int> GetAgentId(string userId);

    Task<bool> ExistsById(string userId);

    Task<bool> UserWithPhoneExists(string phoneNumber);

    Task<bool> UserHasRents(string userId);

    Task Create(string userId, string phoneNumber);
}
