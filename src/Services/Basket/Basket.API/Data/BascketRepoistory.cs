

using Marten;

namespace Basket.API.Data
{
    public class BascketRepoistory(IDocumentSession documentSession) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await documentSession.LoadAsync<ShoppingCart>(userName, cancellationToken);
            return basket is null ? throw new BasketNotFoundException(userName) : basket; 
        }
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            documentSession.Delete<ShoppingCart>(userName);
            await documentSession.SaveChangesAsync();
            return true;
        }


        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            documentSession.Store<ShoppingCart>(basket);
            await documentSession.SaveChangesAsync();
            return basket;
        }
    }
}
