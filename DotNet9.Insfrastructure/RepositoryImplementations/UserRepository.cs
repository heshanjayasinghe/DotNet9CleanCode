using DotNet9.Domain.DatabaseEntities;
using DotNet9.Domain.RepositoryInterfaces;

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
