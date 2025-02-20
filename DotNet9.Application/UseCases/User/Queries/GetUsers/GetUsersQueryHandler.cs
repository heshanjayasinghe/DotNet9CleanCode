using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.User.Commands;
using MediatR;
namespace DotNet9.Application.UseCases.User.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserListResponseDto>
    {
        private readonly IUserService _userService;
        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserListResponseDto> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) { 
                 throw new ArgumentNullException(nameof(request));
                }
                List<UserDto> result = await _userService.GetUsers(request.UserName);

                return new UserListResponseDto { userList = result.ToList() };

            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
