namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger)
        : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("1f4f26e4-a043-4f5c-9b0b-643483e74ccc");

            var response = await orderingService.GetOrdersByCustomer(customerId);

            Orders = response.Orders;

            return Page();
        }
    }
}