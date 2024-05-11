using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReservationApp.Domain;
using RestaurantReservationApp.Domain.Entities;
using System.Drawing;

namespace RestaurantReservationApp.Application.Common.User.Commands
{
    public record AddUserCommand(Domain.Entities.User User) : IRequest;
}
