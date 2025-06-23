using DotNet9.Application.RepositoryInterfaces;
using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.Session.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.ServiceImplementations
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository) {
            _sessionRepository = sessionRepository;
        }
        public async Task<List<GetSessionsWithSongNoteDetailsDto>> GetSessionsWithSongNoteDetails()
        {
            var result= await _sessionRepository.SessionsWithSongNotes();

            List<GetSessionsWithSongNoteDetailsDto> finalResult = new();
            foreach (var item in result)
            {
                finalResult.Add(new GetSessionsWithSongNoteDetailsDto() { SessionName = item.Name});
            }
            return finalResult;
        }
    }
}
