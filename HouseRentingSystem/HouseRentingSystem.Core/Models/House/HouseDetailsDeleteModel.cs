namespace HouseRentingSystem.Core.Models.House
{
    public class HouseDetailsDeleteModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;
    }
}
