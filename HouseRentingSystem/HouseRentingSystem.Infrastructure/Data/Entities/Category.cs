using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.DataConstants.Category;

namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxCategoryName)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<House> Houses { get; set; } = new List<House>();
    }
}
