using Refit;
using Shopping.Web.Models.Catalog;

namespace Shopping.Web.Services;

public interface ICatalogService
{
    [Get("/catalog/products?pageNumber{pageNumber}&pageSize={pageSize}")]
    Task<GetProductsResponse> GetProductsAsync(int? pageNumber = 1, int pageSize = 10);

    [Get("/catalog/Product/{id}")]
    Task<GetProductByIdResponse> GetProduct(Guid id);

    [Get("/catalog/products/category/{category}")]
    Task<GetProductsByCategoryResponse> GetProductsByCategoryAsync(string category);
}
