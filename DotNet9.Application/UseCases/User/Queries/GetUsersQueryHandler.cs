using DotNet9.Application.ServiceInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.UseCases.User.Commands
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserListResponseDto?>
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
                var result = await _userService.GetUsers(request.UserName);

                return new UserListResponseDto { userList = result.ToList() };

            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
