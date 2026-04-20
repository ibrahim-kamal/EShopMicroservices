

namespace Shopping.Web.Pages
{
    public class IndexModel(ICatalogService catalogServices, IBasketService basketService, ILogger<IndexModel> logger) : PageModel
    {

        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();


        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Index page visited");
            var result = await catalogServices.GetProducts();
            ProductList = result.Products;
            return Page();
        }


        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("Add to cart button clicked productId:{productId}", productId);
            var productResponse = await catalogServices.GetProduct(productId);
            var basket = await LoadUserBasket();

            //return Ok();
        }

        private async Task<ShoppingCartModel> LoadUserBasket()
        {
            var username = "dev";
            ShoppingCartModel basket;
            try
            {
                var getBasketResponse = await basketService.GetBasket(username);
                basket = getBasketResponse.Cart;

            }
            catch (Exception ex)
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
}
