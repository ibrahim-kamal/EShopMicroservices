namespace Shopping.Web.Pages
{
    public class CartModel(IBasketService _basketService ,ILogger<CartModel>logger) : PageModel
    {
        public ShoppingCartModel Cart { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Get Cart View");

            Cart = await _basketService.LoadUserBasket();            

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(Guid productId)
        {
            Cart = await _basketService.LoadUserBasket();
            Cart.Items.RemoveAll(i => i.ProductId == productId);
            await _basketService.StoreBasket(new StoreBasketRequest(Cart));
            return RedirectToPage("Cart");
        }
    }
}