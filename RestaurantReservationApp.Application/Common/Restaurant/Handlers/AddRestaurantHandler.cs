using MediatR;
using RestaurantReservationApp.Application.Common.Restaurant.Commands;
using RestaurantReservationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationApp.Application.Common.Restaurant.Handlers
{
    public class AddRestaurantHandler : IRequestHandler<AddRestaurantCommand>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public AddRestaurantHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task Handle(AddRestaurantCommand request, CancellationToken cancellationToken)
        {
            await _restaurantRepository.AddRestaurant(request.Restaurant, cancellationToken);
        }
    }
}
