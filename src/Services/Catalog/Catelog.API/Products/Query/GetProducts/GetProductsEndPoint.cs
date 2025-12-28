namespace Catelog.API.Products.Query.GetProducts
{
    public class GetProductsEndPoint : CarterModule
    {
        public record GetProductsRequest(int? PageNumber=1,int? PageSize=10);
        public record GetProductsResponse(IEnumerable<Product> Products);
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {
                var result = await sender.Send(request.Adapt<GetProductsQuery>());
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
