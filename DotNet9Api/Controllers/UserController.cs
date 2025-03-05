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
        private readonly ILogger<UserController> _logger;
        public UserController (
            IUserService userService,
            IMediator mediator,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string userName) {

            UserListResponseDto user =await _mediator.Send(new GetUsersQuery() { UserName=userName});
            _logger.LogInformation("users captured");
            _logger.LogCritical("users captured");
            _logger.LogTrace("users captured");
            return Ok(user);    
        }

        [HttpGet("WithoutCache")]
        public async Task<IActionResult> GetWithoutCache([FromQuery] string userName)
        {
            
            UserListResponseDto user = await _mediator.Send(new GetUsersWithoutCacheQuery() { UserName = userName });
            throw new Exception("this is a new exception");
            //return Ok(user);
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
