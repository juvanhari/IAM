using Idm.Application.Dtos;

namespace Idm.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(UserDto User) : ICommand<CreateUserResult>;

    public record CreateUserResult(Guid Id);
}
