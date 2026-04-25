using Microsoft.Extensions.Logging;
using Shopping.Web.Services;

namespace Shopping.Web.Pages
{
    public class ProductDetailModel(ICatalogService _catalogService, IBasketService _basketService, ILogger<ProductPageModel> logger) : PageModel
    {

        public ProductModel Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var response = await _catalogService.GetProduct(productId.Value);
            Product = response.Product;
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("Add to cart button clicked productId:{productId}", productId);
            var productResponse = await _catalogService.GetProduct(productId);
            var basket = await _basketService.LoadUserBasket();
            basket.Items.Add(new ShoppingCartItem
            {
                ProductId = productId,
                ProductName = productResponse.Product.Name,
                Price = productResponse.Product.Price,
                Quantity = Quantity,
                Color = Color
            });

            await _basketService.StoreBasket(new StoreBasketRequest(basket));
            return RedirectToPage("Cart");
        }
    }
}