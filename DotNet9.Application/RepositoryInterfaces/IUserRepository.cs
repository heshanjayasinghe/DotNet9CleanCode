using DotNet9.Domain.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersList(string? username);
    }
}
