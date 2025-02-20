using DotNet9.Application.UseCases.Session.Queries;
using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Application.UseCases.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet9.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SessionController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var sessionDetails = await _mediator.Send(new GetSessionsWithSongNoteDetailsQuery() {  });
            return Ok(sessionDetails);


        }
    }


}
