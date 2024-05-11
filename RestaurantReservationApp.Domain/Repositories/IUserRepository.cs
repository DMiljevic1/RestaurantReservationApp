using RestaurantReservationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationApp.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user, CancellationToken cancellationToken);
    }
}
