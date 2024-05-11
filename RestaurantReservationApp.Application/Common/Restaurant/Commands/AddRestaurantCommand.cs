using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationApp.Application.Common.Restaurant.Commands
{
    public record AddRestaurantCommand(Domain.Entities.Restaurant Restaurant) : IRequest;
}
