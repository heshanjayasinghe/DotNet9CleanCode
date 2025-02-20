using DotNet9.Domain.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Domain.RepositoryInterfaces
{
    public interface ISessionRepository
    {
        public Task<List<Session>> SessionsWithSongNotes();
    }
}
