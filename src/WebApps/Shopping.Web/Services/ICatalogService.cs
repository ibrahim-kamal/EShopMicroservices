namespace Shopping.Web.Services;

public interface ICatalogService
{
    [Get("/catalog/products?pageNumber{pageNumber}&pageSize={pageSize}")]
    Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int pageSize = 10);

    [Get("/catalog/Product/{id}")]
    Task<GetProductByIdResponse> GetProduct(Guid id);

    [Get("/catalog/products/category/{category}")]
    Task<GetProductsByCategoryResponse> GetProductsByCategoryAsync(string category);
}
