using Microsoft.Extensions.Logging;
using Shopping.Web.Services;
using System.Drawing;

namespace Shopping.Web.Pages
{
    public class ProductPageModel(ICatalogService _catalogService,IBasketService _basketService, ILogger<ProductPageModel> logger) : PageModel
    {

        public IEnumerable<string> CategoryList { get; set; } = [];
        public IEnumerable<ProductModel> ProductList { get; set; } = [];


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {

            var response = await _catalogService.GetProducts();
            CategoryList = response.Products.SelectMany(p => p.Category).ToList();
            ProductList = response.Products;
            if (!string.IsNullOrEmpty(categoryName))
            {
                ProductList = response.Products.Where(p => p.Category.Contains(categoryName)).ToList();
                SelectedCategory = categoryName;
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
                Quantity = 1,
                Color = "Black"
            });

            await _basketService.StoreBasket(new StoreBasketRequest(basket));
            return RedirectToPage("Cart");
        }
    }
}