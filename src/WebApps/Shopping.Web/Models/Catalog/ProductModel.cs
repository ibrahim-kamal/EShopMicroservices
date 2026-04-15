namespace Shopping.Web.Models.Catalog
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Category { get; set; } = new();
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }

    public record GetProductsResponse(IEnumerable<ProductModel> Products);
    public record GetProductByIdResponse(ProductModel Product);
    public record GetProductsByCategoryResponse(IEnumerable<ProductModel> Products);
}
