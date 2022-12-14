using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Exeptions;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HouseRentingServiseCollectionExtension
    {
        public static IServiceCollection AddApplicationServises(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }
    }
}
