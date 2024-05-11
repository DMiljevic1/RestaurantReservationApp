using Microsoft.EntityFrameworkCore;
using RestaurantReservationApp.Application.Common.User.Handlers;
using RestaurantReservationApp.Domain.Repositories;
using RestaurantReservationApp.Infrastructure.DatabaseContext;
using RestaurantReservationApp.Infrastructure.Repositories;

namespace RestaurantReservationApp.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureRepositories(services, configuration);
            ConfigureApplicationServices(services, configuration);
        }
        private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultDatabase")));
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddUserHandler).Assembly));
        }
    }
}
