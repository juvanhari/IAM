using BuildingBlocks.Pagination;
using Idm.Application.Users.Queries.GetUsers;

namespace Idm.Api.Endpoints
{
    public record GetUsersResponse(PaginatedResult<UserDto> Users);

    public class GetUsers : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetUsersQueryRequest(request));

                var response = result.Adapt<GetUsersResponse>();

                return Results.Ok(response);
            })
            .WithName("GetUsers")
            .Produces<GetUsersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Users")
            .WithDescription("Get Users");
        }
    }
}
