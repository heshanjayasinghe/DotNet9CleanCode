using DotNet9.Application.ServiceInterfaces;
using DotNet9.Application.UseCases.User.Queries.GetUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var result = await _userService.GetUsersWithoutCache(request.UserName);

                return new UserListResponseDto { userList = result.ToList() };

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
