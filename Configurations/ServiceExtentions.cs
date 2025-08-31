using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestrurantPG.Data;
using RestrurantPG.Services.Implementations;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Configurations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddConnectionString(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
