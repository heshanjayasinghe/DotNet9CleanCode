using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.UseCases.Session.Queries
{
    public record GetSessionsWithSongNoteDetailsDto
    {
        public required string SessionName { get; set; }
    }
}
