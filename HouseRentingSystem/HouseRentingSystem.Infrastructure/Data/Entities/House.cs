using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Data.DataConstants.House;

namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    public class House
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxHouseTitle)] 
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxHouseAddress)] 
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(MaxHouseDescription)] 
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        [Range(typeof(decimal), "0.0", "20000.0")]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Required]
        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }

        public bool IsDeleted { get; set; } 

    }
}
