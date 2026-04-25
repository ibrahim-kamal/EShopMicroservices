namespace Shopping.Web.Services;

public interface IBasketService
{

    [Get("/basket//Basket/{userName}")]
    Task<GetBasketResponse> GetBasket(string userName);

    [Post("/basket/basket")]
    Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

    [Delete("/basket/basket/{UserName}")]
    Task<DeleteBasketResponse> DeleteBasket(string userName);

    [Post("/basket/basket/checkout")]
    Task<CheckBasketResponse> BasketCheckout(CheckBasketRequest request);


    public async Task<ShoppingCartModel> LoadUserBasket()
    {
        var username = "dev";
        ShoppingCartModel basket;
        try
        {
            var getBasketResponse = await GetBasket(username);
            basket = getBasketResponse.Cart;

        }
        catch (ApiException apiException) when (apiException.StatusCode == System.Net.HttpStatusCode.NotFound)
        {

            basket = new ShoppingCartModel()
            {
                UserName = username,
                Items = []
            };
        }

        return basket;
    }


}
