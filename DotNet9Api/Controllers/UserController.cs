using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNet9API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   private readonly IUserService _userService;
        private readonly IMediator _mediator;
        public UserController (
            IUserService userService,
            IMediator mediator) {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string userName) {
            
            var user=await _mediator.Send(new GetUsersQuery() { UserName=userName});
            return Ok(user);    
        }

        [HttpGet("UsingService")]
        public async Task<IActionResult> GetUsingService([FromQuery] string userName)
        {

            var user = await _userService.GetUsers(userName);
            return Ok(user);
        }
    }
}
