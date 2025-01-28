using DotNet9.Application.UseCases.User.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.UseCases.User.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UserListResponseDto>
    {
        public string? UserName { get; set; }
    }
}
