using Idm.Application.Dtos;

namespace Idm.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(UserDto User) : ICommand<UpdateUserResult>;

    public record UpdateUserResult(bool IsSuccess);
}
