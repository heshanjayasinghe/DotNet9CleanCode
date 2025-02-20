using MediatR;

namespace DotNet9.Application.UseCases.User.Commands
{
    public class GetUsersWithoutCacheQuery : IRequest<UserListResponseDto>
    {
        public string? UserName { get; set; }
    }
}
