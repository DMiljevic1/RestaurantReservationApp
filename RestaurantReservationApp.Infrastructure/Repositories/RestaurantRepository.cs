using RestaurantReservationApp.Domain.Entities;
using RestaurantReservationApp.Domain.Repositories;
using RestaurantReservationApp.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationApp.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRestaurant(Restaurant restaurant, CancellationToken cancellationToken)
        {
            if(restaurant != null)
            {
                await _dbContext.Restaurants.AddAsync(restaurant, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
