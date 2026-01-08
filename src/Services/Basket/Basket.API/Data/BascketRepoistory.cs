namespace Basket.API.Data
{
    public class BascketRepoistory(IDocumentSession documentSession) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await documentSession.LoadAsync<ShoppingCart>(userName, cancellationToken);
            return basket is null ? throw new BasketNotFoundException(userName) : basket; 
        }
        public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


        public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
