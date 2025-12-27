using Marten.Schema;

namespace Catelog.API.Data
{
    public class CatelogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguratedProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguratedProducts() => new List<Product>()
        {
            new Product
            {
                Id = Guid.Parse("a3f4b2d1-6c8e-4a5b-9d3e-1f8a2c4e7b90"),
                Name = "Laptop Pro 16",
                Category = new List<string> { "Electronics", "Computers" },
                Description = "High performance laptop for developers",
                ImageFile = "laptop.png",
                Price = 2200m
            },
            new Product
            {
                Id = Guid.Parse("b7e1c9a4-2d6f-4f8b-8a0d-5e3c9b1f6a42"),
                Name = "Wireless Mouse",
                Category = new List<string> { "Electronics", "Accessories" },
                Description = "Ergonomic wireless mouse",
                ImageFile = "mouse.png",
                Price = 35m
            },
            new Product
            {
                Id = Guid.Parse("c2a9e8f7-1b4d-4c6a-9f5e-0a7d3e8b2c91"),
                Name = "Mechanical Keyboard",
                Category = new List<string> { "Electronics", "Accessories" },
                Description = "RGB mechanical keyboard",
                ImageFile = "keyboard.png",
                Price = 120m
            },
            new Product
            {
                Id = Guid.Parse("d9f3a2b6-7e1c-4a8d-8f0b-6c5e2a1b9d34"),
                Name = "27-inch Monitor",
                Category = new List<string> { "Electronics", "Displays" },
                Description = "4K UHD monitor",
                ImageFile = "monitor.png",
                Price = 450m
            },
            new Product
            {
                Id = Guid.Parse("e1b7d6f2-8a4c-4e9f-9d3a-0c5b1f7e2a68"),
                Name = "USB-C Hub",
                Category = new List<string> { "Electronics", "Accessories" },
                Description = "Multi-port USB-C hub",
                ImageFile = "hub.png",
                Price = 60m
            },
            new Product
            {
                Id = Guid.Parse("f4a2e1c7-9b6d-4d3a-8f5e-7c1b0a9e6d23"),
                Name = "External SSD 1TB",
                Category = new List<string> { "Electronics", "Storage" },
                Description = "Fast portable SSD storage",
                ImageFile = "ssd.png",
                Price = 150m
            },
            new Product
            {
                Id = Guid.Parse("0a9e6b4f-5d7c-4f2a-9e3d-1c8b6a7f0e45"),
                Name = "Noise Cancelling Headphones",
                Category = new List<string> { "Electronics", "Audio" },
                Description = "Over-ear noise cancelling headphones",
                ImageFile = "headphones.png",
                Price = 300m
            },
            new Product
            {
                Id = Guid.Parse("1c7a9e3f-8b6d-4a5c-9f0e-2d1b7e6c3a94"),
                Name = "Webcam HD",
                Category = new List<string> { "Electronics", "Accessories" },
                Description = "1080p HD webcam",
                ImageFile = "webcam.png",
                Price = 80m
            },
            new Product
            {
                Id = Guid.Parse("2e6b7c0a-4d9f-4a3e-8c1b-5f7e2d9a6b04"),
                Name = "Smartphone Stand",
                Category = new List<string> { "Accessories" },
                Description = "Adjustable desk phone stand",
                ImageFile = "stand.png",
                Price = 15m
            },
            new Product
            {
                Id = Guid.Parse("3d0b9e7a-5f2c-4c6e-8a1f-7b3e9d0a2c58"),
                Name = "Portable Speaker",
                Category = new List<string> { "Electronics", "Audio" },
                Description = "Bluetooth portable speaker",
                ImageFile = "speaker.png",
                Price = 90m
            },
            new Product
            {
                Id = Guid.Parse("4f7a3b1e-2c9d-4e6a-8b5f-0d7e1c9a3f24"),
                Name = "Gaming Mouse Pad",
                Category = new List<string> { "Accessories", "Gaming" },
                Description = "Large gaming mouse pad",
                ImageFile = "mousepad.png",
                Price = 25m
            },
            new Product
            {
                Id = Guid.Parse("5c9e2b1a-6f7d-4a3c-8e0b-9d1f7c2a5e64"),
                Name = "Smart Watch",
                Category = new List<string> { "Electronics", "Wearables" },
                Description = "Fitness and health tracking smartwatch",
                ImageFile = "watch.png",
                Price = 200m
            },
            new Product
            {
                Id = Guid.Parse("6b1a2f9c-7e5d-4c0a-9e3f-8d6b1a7c5f42"),
                Name = "Power Bank 20000mAh",
                Category = new List<string> { "Electronics", "Accessories" },
                Description = "High capacity power bank",
                ImageFile = "powerbank.png",
                Price = 70m
            },
            new Product
            {
                Id = Guid.Parse("7e5f9d2a-6c1b-4a3e-8f0d-2b7c9a1e5f84"),
                Name = "Laptop Backpack",
                Category = new List<string> { "Bags", "Accessories" },
                Description = "Water-resistant laptop backpack",
                ImageFile = "backpack.png",
                Price = 85m
            },
            new Product
            {
                Id = Guid.Parse("8a3c7e5f-9d1b-4e6a-8c2f-0a7b1d9e5c34"),
                Name = "Desk Lamp LED",
                Category = new List<string> { "Home", "Office" },
                Description = "Adjustable LED desk lamp",
                ImageFile = "lamp.png",
                Price = 55m
            }
        };

    }
}
