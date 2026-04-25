namespace Shopping.Web.Pages
{
    public class CheckOutModel(IOrderingService _orderserice,IBasketService _basketService,ILogger<CheckOutModel> logger) : PageModel
    {

        [BindProperty]
        public BasketCheckoutModel Order { get; set; } = default!;

        public ShoppingCartModel Cart { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            try {
                var response = await _basketService.GetBasket("dev");
                Cart = response.Cart;
                return Page();
            }
            catch (ApiException apiException) when (apiException.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return RedirectToPage("Cart");
            }
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var response = await _basketService.GetBasket("dev");
            Cart = response.Cart;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.CustomerId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa");
            Order.Username = Cart.UserName;
            Order.TotalPrice= Cart.TotalPrice;


            var checkoutResponse = await _basketService.BasketCheckout(new CheckBasketRequest(Order));

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}