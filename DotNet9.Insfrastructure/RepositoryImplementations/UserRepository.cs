using DotNet9.Application.RepositoryInterfaces;
using DotNet9.Domain.DatabaseEntities;

namespace DotNet9.Insfrastructure.RepositoryImplementations
{

    public class UserRepository : IUserRepository
    {
        public UserRepository() { }

        public async Task<List<User>> GetUsersList(string? username)
        {
            Thread.Sleep(5000);
            return new List<User>() { new User() { Name = "lahiru", UserId="123" } };
        }
    }
}
