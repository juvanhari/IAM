namespace Idm.Application.Users.Queries.GetUsers
{

    public record GetUsersQueryRequest(PaginationRequest PaginationRequest)
   : IQuery<GetUsersQueryResult>;

    public record GetUsersQueryResult(PaginatedResult<UserDto> Users);
}
