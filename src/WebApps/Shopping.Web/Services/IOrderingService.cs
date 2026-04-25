namespace Shopping.Web.Services;

public interface IOrderingService
{

    [Get("order/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetOrdersResponse> GetOrders(int? pageIndex=1, int? pageSize = 10);
    [Get("order/orders/{orderName}")]
    Task<GetOrderByNameResponse> GetOrdersByOrderName(string orderName);
    [Get("order/orders/customer/{customerId}")]
    Task<GetOrdersByCustomerResponse> GetOrdersByCustomerId(Guid CustomerId);
}
