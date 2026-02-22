





namespace Ordering.Api.Endpoints
{
    public record GetOrderByNameResponse(IEnumerable<OrderDto> Order);
    public class GetOrdersByName : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{orderName}", async (String orderName, ISender sender) =>
            {
                var command = new GetOrdersByNameQuery(orderName);
                var result = await sender.Send(command);
                var response = result.Adapt<GetOrderByNameResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrdersByOrderName")
            .Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithDescription("Get Orders By Order Name")
            .WithSummary("Get Orders By Order Name");
        }
    }
}
