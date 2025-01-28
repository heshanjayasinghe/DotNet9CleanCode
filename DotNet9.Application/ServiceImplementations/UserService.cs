using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.ServiceImplementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository ;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public Task<List<UserDto>> GetUsers(string userName) {
            return Task.FromResult(new List<UserDto> { new UserDto { UserName = "Heshan" } });
        }
    }
}
