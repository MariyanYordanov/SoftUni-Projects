using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.House
{
    public class AllHousesQueryModel
    {
        public const int HousesPerPage = 3;

        public string? Category { get; set; }

        [Display(Name = "Search by text")]
        public string? SearchTerm { get; set; }

        public HouseSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalHousesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();
    }
}


