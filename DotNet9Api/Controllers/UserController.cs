using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Application.UseCases.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet9API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
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

            UserListResponseDto user =await _mediator.Send(new GetUsersQuery() { UserName=userName});
            return Ok(user);    
        }

        [HttpGet("WithoutCache")]
        public async Task<IActionResult> GetWithoutCache([FromQuery] string userName)
        {

            UserListResponseDto user = await _mediator.Send(new GetUsersWithoutCacheQuery() { UserName = userName });
            return Ok(user);
        }

        //Directly use the service without going through query handler
        [HttpGet("UsingService")]
        public async Task<IActionResult> GetUsingService([FromQuery] string userName)
        {

            List<UserDto> user = await _userService.GetUsers(userName);
            return Ok(user);
        }
    }
}
