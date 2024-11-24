using BuildingBlocks.Pagination;
using Idm.Application.Users.Queries.GetUserById;

namespace Idm.Api.Endpoints
{
    public record GetUserByIdResponse(UserDto User);

    public class GetUserById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new GetUserByIdQuery(Id));

                var response = result.Adapt<GetUserByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetUserById")
            .Produces<GetUsersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get User By Id")
            .WithDescription("Get User By Id");
        }
    }
}
