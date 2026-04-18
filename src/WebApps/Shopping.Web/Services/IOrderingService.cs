namespace Shopping.Web.Services;

public interface IOrderingService
{

    [Get("order/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetOrdersResponse> GetOrders(int? pageIndex, int? pageSize);
    [Get("order/orders/{orderName}")]
    Task<GetOrderByNameResponse> GetOrdersByOrderName(string orderName);
    [Get("order/orders/customer/{customerId}")]
    Task<GetOrdersByCustomerResponse> GetOrdersByCustomerId(Guid CustomerId);
}
