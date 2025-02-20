using DotNet9.Application.UseCases.User.Commands;
using MediatR;


namespace DotNet9.Application.UseCases.User.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UserListResponseDto>
    {
        public string? UserName { get; set; }
    }
}
