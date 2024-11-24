using Idm.Application.Users.Commands.DeleteUser;

namespace Idm.Api.Endpoints
{
    public record DeleteUserResponse(bool IsSuccess);

    public class DeleteUser : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/users/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteUserCommand(Id));

                var response = result.Adapt<DeleteUserResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteUser")
            .Produces<DeleteUserResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete User")
            .WithDescription("Delete User");
        }
    }
}
