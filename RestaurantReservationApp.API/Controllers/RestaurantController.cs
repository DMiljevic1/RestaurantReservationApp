using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservationApp.Application.Common.Restaurant.Commands;
using RestaurantReservationApp.Domain.Entities;

namespace RestaurantReservationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddRestaurant([FromBody]Restaurant restaurant, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new AddRestaurantCommand(restaurant), cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }
    }
}
