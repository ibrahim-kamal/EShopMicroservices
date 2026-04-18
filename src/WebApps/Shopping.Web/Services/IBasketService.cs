namespace Shopping.Web.Services;

public interface IBasketService
{

    [Get("/basket/basket/{UserName}")]
    Task<GetBasketResponse> GetBasket(string userName);

    [Post("/basket/basket")]
    Task<StoreBasketResponse> StoreBasket(CheckBasketRequest request);

    [Delete("/basket/basket/{UserName}")]
    Task<DeleteBasketResponse> DeleteBasket(string userName);

    [Post("/basket/basket/checkout")]
    Task<CheckBasketResponse> BasketCheckout(CheckBasketRequest request);




}
