namespace Idm.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IApplicationDbContext dbContext, ILogger<CreateUserCommandHandler> logger) : ICommandHandler<CreateUserCommand, CreateUserResult>
    {
        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Create user command request for {command.User.Firstname} {command.User.Lastname}");

            var user = User.Create(UserId.Of(Guid.NewGuid()), command.User.Firstname, command.User.Lastname, command.User.Department,
                command.User.Joindate, command.User.Manager, command.User.EmployeeType);

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateUserResult(user.Id.Value);
        }
    }
}
