using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetDevPack.Identity.Example.Configurations
{
    public static class IdentityDatabaseConfig
    {
        public static void AddApiIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Default EF Context for Identity (inside of the NetDevPack.Identity)
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                   options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                       b => b.MigrationsAssembly("NetDevPack.Identity.Example")));

            // Default Identity configuration from NetDevPack.Identity
            services.AddIdentityConfiguration();

        }
    }
}