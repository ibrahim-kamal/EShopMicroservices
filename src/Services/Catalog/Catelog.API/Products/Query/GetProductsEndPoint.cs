
namespace Catelog.API.Products.Query
{
    public class GetProductsEndPoint : CarterModule
    {
        public record GetProductsRequest();
        public record GetProductsResponse(IEnumerable<Product> Products);
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
                .WithName("GetProducts")
                .Produces<GetProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Get Products")
                .WithSummary("Get Products");
        }
    }
}
