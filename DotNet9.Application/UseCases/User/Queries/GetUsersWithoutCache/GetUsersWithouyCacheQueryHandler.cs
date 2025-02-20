using DotNet9.Application.ServiceInterfaces;
using MediatR;

namespace DotNet9.Application.UseCases.User.Commands
{
    public class GetUsersWithouyCacheQueryHandler : IRequestHandler<GetUsersWithoutCacheQuery, UserListResponseDto?>
    {
        private readonly IUserService _userService;
        public GetUsersWithouyCacheQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

       

        public async Task<UserListResponseDto?> Handle(GetUsersWithoutCacheQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) { 
                 throw new ArgumentNullException(nameof(request));
                }
                var result = await _userService.GetUsersWithoutCache(request?.UserName);

                return new UserListResponseDto { userList = result.ToList() };

            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
