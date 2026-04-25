namespace Shopping.Web.Pages
{
    public class IndexModel(ICatalogService catalogServices, IBasketService basketService, ILogger<IndexModel> logger) : PageModel
    {

        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();
        [BindProperty]
        public string Color { get; set; } = default;
        [BindProperty]
        public int Quantity { get; set; } = default;
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
            var basket = await basketService.LoadUserBasket();
            basket.Items.Add(new ShoppingCartItem { 
                ProductId = productId,
                ProductName =productResponse.Product.Name,
                Price = productResponse.Product.Price,
                Quantity = 1,
                Color = Color 
            });

            await basketService.StoreBasket(new StoreBasketRequest(basket));
            return RedirectToPage("Cart");
        }

    }
}
