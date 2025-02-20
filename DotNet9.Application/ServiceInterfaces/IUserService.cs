using DotNet9.Application.UseCases.User.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers(string? userName);
        Task<List<UserDto>> GetUsersWithoutCache(string? userName);
    }
}
