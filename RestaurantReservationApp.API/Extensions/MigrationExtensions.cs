using Microsoft.EntityFrameworkCore;
using RestaurantReservationApp.Infrastructure.DatabaseContext;

namespace RestaurantReservationApp.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            IServiceScope scope = app.ApplicationServices.CreateScope();
            using RestaurantDbContext dbContext = scope.ServiceProvider.GetRequiredService<RestaurantDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
