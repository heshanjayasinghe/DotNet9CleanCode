using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Application.UseCases.User.Commands
{
    public class UserDto
    {
        public string UserName { get; set; }    
    }

    public class UserListResponseDto
    {

        public List<UserDto> userList { get; set; }
      }
}
