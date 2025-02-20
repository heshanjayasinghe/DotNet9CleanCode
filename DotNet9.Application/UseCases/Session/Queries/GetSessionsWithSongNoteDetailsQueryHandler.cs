using DotNet9.Application.ServiceImplementations;
using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Application.UseCases.User.Queries.GetUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.UseCases.Session.Queries
{

    public class GetSessionsWithSongNoteDetailsQueryHandler : IRequestHandler<GetSessionsWithSongNoteDetailsQuery, List<GetSessionsWithSongNoteDetailsDto>>
    {   private ISessionService _sessionService;
        public GetSessionsWithSongNoteDetailsQueryHandler(ISessionService sessionService) {
            _sessionService = sessionService;
        }

        public async Task<List<GetSessionsWithSongNoteDetailsDto>> Handle(GetSessionsWithSongNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _sessionService.GetSessionsWithSongNoteDetails();
            return result;
        }

    }


}
