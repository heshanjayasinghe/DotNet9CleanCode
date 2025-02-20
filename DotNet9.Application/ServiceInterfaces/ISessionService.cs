using DotNet9.Application.UseCases.Session.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.ServiceInterfaces
{
    public interface ISessionService
    {
        public Task<List<GetSessionsWithSongNoteDetailsDto>> GetSessionsWithSongNoteDetails();
    }
}
