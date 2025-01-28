using DotNet9.Domain.DatabaseEntities;
using DotNet9.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Insfrastructure.RepositoryImplementations
{
   // private readonly 
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }

        public async Task<List<User>> GetUsersList(string? username)
        {
            Thread.Sleep(5000);
            return new List<User>() { new User() { Name = "lahiru" } };
        }
    }
}
