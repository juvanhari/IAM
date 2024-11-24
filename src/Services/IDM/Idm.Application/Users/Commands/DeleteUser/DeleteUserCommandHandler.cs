namespace Idm.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteUserCommandHandler> logger) : ICommandHandler<DeleteUserCommand, DeleteUserResult>
    {
        public async Task<DeleteUserResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Delete user command request for user id {command.Id} ");

            var userId = UserId.Of(command.Id);
            var user = await dbContext.Users
                .FindAsync([userId], cancellationToken: cancellationToken);

            if (user is null)
            {
                throw new NotFoundException("User", command.Id.ToString());
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteUserResult(true);
        }
    }
}
