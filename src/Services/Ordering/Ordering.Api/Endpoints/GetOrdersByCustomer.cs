

namespace Ordering.Api.Endpoints
{
    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Order);
    public class GetOrdersByCustomer : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/customerId", async (Guid customerId, ISender sender) =>
            {
                var command = new GetOrdersByCustomerQuery(customerId);
                var result = await sender.Send(command);
                var response = result.Adapt<GetOrdersByCustomerResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrdersByCustomerId")
            .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithDescription("Get Orders By Customer Id")
            .WithSummary("Get Orders By Customer Id");
        }
    }
}
