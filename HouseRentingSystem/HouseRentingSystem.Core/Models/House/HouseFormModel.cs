using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.DataConstants.House;

namespace HouseRentingSystem.Core.Models.House;

public class HouseFormModel
{
    public int Id { get; init; }

    [Required]
    [StringLength(MaxHouseTitle, MinimumLength = MinHouseTitle)]
    public string Title { get; init; } = null!;

    [Required]
    [StringLength(MaxHouseAddress, MinimumLength = MinHouseAddress)]
    public string Address { get; init; } = null!;

    [Required]
    [StringLength(MaxHouseDescription, MinimumLength = MinHouseDescription)]
    public string Description { get; init; } = null!;

    [Required]
    [Display(Name = "Image Url")]
    public string ImageUrl { get; init; } = null!;

    [Required]
    [Display(Name = "Price Per Month")]
    [Range(typeof(decimal), MinPricePerMonth, MaxPricePerMonth, 
        ErrorMessage = "Price per month must be positive number and less than {2} leva.")]
    public decimal PricePerMonth { get; init; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; init; }

    public IEnumerable<HouseCategoryModel> HouseCategories { get; set; } = new List<HouseCategoryModel>();
}
