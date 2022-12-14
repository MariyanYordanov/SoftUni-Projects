namespace HouseRentingSystem.Core.Exeptions
{
    public class HouseRentingExeption : ApplicationException
    {
        public HouseRentingExeption()
        {
        }

        public HouseRentingExeption(string errorMessage)
            : base (errorMessage)
        {
        }
    }
}
