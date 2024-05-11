using MediatR;
using RestaurantReservationApp.Application.Common.User.Commands;
using RestaurantReservationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationApp.Application.Common.User.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.AddUser(request.User, cancellationToken);
        }
    }
}
