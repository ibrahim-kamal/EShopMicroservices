namespace Shopping.Web.Pages
{
    public class IndexModel(ICatalogService catalogServices,ILogger<IndexModel> logger) : PageModel
    {

        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();


        public async Task<IActionResult> OnGet()
        {
            logger.LogInformation("Index page visited");
            var result = await catalogServices.GetProducts();
            ProductList = result.Products;
            return Page();
        }
    }
}
