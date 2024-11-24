namespace Idm.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetUserByIdQueryHandler> logger) : IQueryHandler<GetUserByIdQuery, GetUserByIdResult>
    {
        public async Task<GetUserByIdResult> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                          .AsNoTracking()
                          .Where(u => u.Id == UserId.Of(query.Id))
                          .FirstOrDefaultAsync();

            return new GetUserByIdResult(user!.ToUserDto());
        }
    }
}
