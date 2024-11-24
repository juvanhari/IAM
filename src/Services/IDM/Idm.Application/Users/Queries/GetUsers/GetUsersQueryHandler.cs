namespace Idm.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler(IApplicationDbContext dbContext, ILogger<GetUsersQueryHandler> logger) : IQueryHandler<GetUsersQueryRequest, GetUsersQueryResult>
    {
        public async Task<GetUsersQueryResult> Handle(GetUsersQueryRequest query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Users.LongCountAsync(cancellationToken);

            var users = await dbContext.Users
                           .OrderBy(o => o.FirstName)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);


            return new GetUsersQueryResult(
                new PaginatedResult<UserDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    users.ToUserDtoList()));
        }
    }
}
