using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservationApp.Application.Common.User.Commands;
using RestaurantReservationApp.Domain.Entities;

namespace RestaurantReservationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]User user, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new AddUserCommand(user), cancellationToken);
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
