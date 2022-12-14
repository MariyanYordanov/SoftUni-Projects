namespace HouseRentingSystem.Core.Exeptions
{
    public interface IGuard
    {
        void AggainstNull<T>(T value, string? errorMessage = null);
    }
}
