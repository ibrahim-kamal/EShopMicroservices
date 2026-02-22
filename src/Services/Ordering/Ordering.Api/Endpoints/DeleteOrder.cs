



using Ordering.Application.Orders.Commands.DeleteOrder;

namespace Ordering.Api.Endpoints
{
    public record DeleteOrderResponse(bool IsSuccess);
    public class DeleteOrder : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders/{orderId}", async (Guid orderId, ISender sender) =>
            {
                var command = new DeleteOrderCommand(orderId);
                var result = await sender.Send(command);
                var response = result.Adapt<DeleteOrderResponse>();
                return Results.Ok(response);
            })
            .WithName("Delete Order")
            .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithDescription("Delete Order")
            .WithSummary("Delete Order");
        }
    }
}
