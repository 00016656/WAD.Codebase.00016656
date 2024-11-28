using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD.Codebase._00016656.Data;
using WAD.Codebase._00016656.Services.Interfaces;
using WAD.Codebase._00016656.Services;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class ConfigurationServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddDbContext<RealEstateDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
