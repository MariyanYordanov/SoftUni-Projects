namespace HouseRentingSystem.Core.Exeptions
{
    public class Guard : IGuard
    {
        public void AggainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exeption = errorMessage == null ?
                    new HouseRentingExeption() :
                    new HouseRentingExeption(errorMessage);

                throw exeption;
            }
        }
    }
}
