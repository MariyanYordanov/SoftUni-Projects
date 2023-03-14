using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.DataConstants.Agent;

namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    public class Agent
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxAgentPhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;
    }
}
