

namespace Ordering.Api.Endpoints
{
    //public record GetOrdersRequest(PaginationRequest paginationRequest);
    public record GetOrdersResponse(PaginatedResult<OrderDto> Order);
    public class GetOrders : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var command = new GetOrdersQuery(paginationRequest);
                var result = await sender.Send(command);
                var response = result.Adapt<GetOrdersResponse>();
                return Results.Ok(response);
            })
            .WithName("Get Orders")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Get Orders")
            .WithSummary("Get Orders");
        }
    }
}
