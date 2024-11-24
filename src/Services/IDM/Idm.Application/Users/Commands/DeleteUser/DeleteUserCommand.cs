

namespace Idm.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : ICommand<DeleteUserResult>;

    public record DeleteUserResult(bool IsSuccess);

}
