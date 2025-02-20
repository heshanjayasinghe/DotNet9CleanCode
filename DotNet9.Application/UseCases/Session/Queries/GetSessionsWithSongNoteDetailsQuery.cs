using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.UseCases.Session.Queries
{
    public class GetSessionsWithSongNoteDetailsQuery : IRequest<List<GetSessionsWithSongNoteDetailsDto>>
    {
    }
}
