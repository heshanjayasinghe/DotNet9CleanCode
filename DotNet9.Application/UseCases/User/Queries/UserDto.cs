
namespace DotNet9.Application.UseCases.User.Commands
{
    public class UserDto
    {
        public required string UserName { get; set; }    
    }

    public class UserListResponseDto
    {

        public required List<UserDto> userList { get; set; }
      }
}
