using Basket.API.Basket.Commands.DeleteBasket;

namespace Basket.API.Basket.Commands.DeleteBasket
{
    //public record DeleteBasketRequest(string UserName);
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/{UserName}", (string UserName, ISender sender) =>
            {

                var result = sender.Send(new DeleteBasketCommand(UserName));
                var response = result.Adapt<DeleteBasketResponse>();
                return Results.Ok( response);
            })
                .WithName("Delete Basket")
                .WithDescription("Delete Basket")
                .WithSummary("Delete Basket")
                .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest);

        }
    }
}
