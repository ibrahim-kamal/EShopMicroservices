namespace Ordering.Domain.Models
{
    public class Products : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

        public static Products Create(ProductId id, string name, decimal price)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            var products = new Products
            {
                Id = id,
                Name = name,
                Price = price
            };
            return products;
        }
    }
}
