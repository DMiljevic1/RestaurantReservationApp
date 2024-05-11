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
    public class UserRepository : IUserRepository
    {
        private readonly RestaurantDbContext _dbContext;
        public UserRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUser(User user, CancellationToken cancellationToken)
        {
            if(user != null)
            {
                await _dbContext.Users.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
