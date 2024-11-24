namespace Idm.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateUserCommandHandler> logger) : ICommandHandler<UpdateUserCommand, UpdateUserResult>
    {
        public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Update user command request for user id {command.User.Id} ");

            var userId = UserId.Of(command.User.Id);
            var user = await dbContext.Users
                .FindAsync([userId], cancellationToken: cancellationToken);

            if (user is null)
            {
                throw new NotFoundException("User", command.User.Id.ToString());
            }

            user.FirstName = command.User.Firstname;
            user.LastName = command.User.Lastname;
            user.Department = command.User.Department;
            user.Manager = command.User.Manager;
            user.Status = command.User.Status;

            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateUserResult(true);
        }
    }
}
