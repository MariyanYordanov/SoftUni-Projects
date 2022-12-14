using System.Security.Claims;

namespace HouseRentingSystem.Extension;

public static class ClaimsPrincipalExtensions
{
    public static string Id(this ClaimsPrincipal user)
        => user
        .FindFirstValue(ClaimTypes.NameIdentifier);
}
