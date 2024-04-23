using Application.Services;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;

namespace API.IoC
{
    public static class DI
    {
        public static void AddSdk(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
