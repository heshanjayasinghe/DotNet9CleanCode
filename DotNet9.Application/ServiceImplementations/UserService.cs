using DotNet9.Application.RepositoryInterfaces;
using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.User.Commands;
using DotNet9.Domain.DatabaseEntities;
using Microsoft.Extensions.Caching.Hybrid;

namespace DotNet9.Application.ServiceImplementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository ;
        private HybridCache _cache;
        public UserService(IUserRepository userRepository, HybridCache cache) {
            _userRepository = userRepository;
            _cache = cache;
        }

        public async Task<List<UserDto>> GetUsers(string? userName) {

            List<User> result= await _cache.GetOrCreateAsync(
            $"users-{userName}", // Unique key to the cache entry
            async cancel => await _userRepository.GetUsersList(userName),
            cancellationToken: new CancellationToken()
             );

            List<UserDto> userDtos = new List<UserDto>();
            foreach (var item in result)
            {
                userDtos.Add(new UserDto() { UserName=item.Name});
            }

            return userDtos;

           
        }

        public async Task<List<UserDto>> GetUsersWithoutCache(string? userName)
        {

            var result = await _userRepository.GetUsersList(userName);

            List<UserDto> userDtos = new List<UserDto>();
            foreach (var item in result)
            {
                userDtos.Add(new UserDto() { UserName = item.Name });
            }

            return userDtos;


        }
    }
}
