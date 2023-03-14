using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.DataConstants.Agent;

namespace HouseRentingSystem.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(MaxAgentPhoneNumber, MinimumLength = MinAgentPhoneNumber)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; init; } = null!;
    }
}

