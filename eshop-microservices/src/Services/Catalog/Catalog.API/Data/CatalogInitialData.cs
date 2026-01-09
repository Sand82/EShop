using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
        {
            return;
        }

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        var products = new List<Product>
    {
        new Product()
        {
            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            Name = "Apple iPhone 15 Pro",
            Description = "Latest Apple smartphone with A17 Pro chip, 6.1-inch Super Retina XDR display, and titanium design.",
            ImageFile = "product-1",
            Price = 999.99M,
            Category = new List<string>{ "Electronics", "Smartphones" }
        },
        new Product()
        {
            Id = new Guid("7e2b1c91-4b6d-4e8a-9c5e-28e1f0c1d2a1"),
            Name = "Sony WH-1000XM5 Headphones",
            Description = "Industry-leading wireless noise-canceling over-ear headphones with up to 30 hours of battery life.",
            ImageFile = "product-2",
            Price = 399.99M,
            Category = new List<string>{ "Electronics", "Audio" }
        },
        new Product()
        {
            Id = new Guid("f5e4d2b0-3c7a-44a1-9b9a-65d2f47a3c2b"),
            Name = "Nike Air Zoom Pegasus 40",
            Description = "Lightweight running shoes with responsive cushioning and breathable mesh upper.",
            ImageFile = "product-3",
            Price = 129.99M,
            Category = new List<string>{ "Fashion", "Shoes" }
        },
        new Product()
        {
            Id = new Guid("9d1c6a34-8f9b-4b55-bc72-61f927b482af"),
            Name = "The Pragmatic Programmer",
            Description = "Classic book on software development practices and principles by Andrew Hunt and David Thomas.",
            ImageFile = "product-4",
            Price = 45.00M,
            Category = new List<string>{ "Books", "Programming" }
        },
        new Product()
        {
            Id = new Guid("d4a1c78e-2e3f-4f41-a5b3-7e8c2b9d3f10"),
            Name = "Samsung 55\" QLED 4K Smart TV",
            Description = "Ultra HD smart TV with Quantum Dot technology, HDR10+, and built-in streaming apps.",
            ImageFile = "product-5",
            Price = 699.99M,
            Category = new List<string>{ "Electronics", "Television" }
        },
        new Product()
        {
            Id = new Guid("a1b2c3d4-5678-4321-9abc-1234567890ab"),
            Name = "Dell XPS 15 Laptop",
            Description = "High-performance laptop with Intel i7 processor, 16GB RAM, 512GB SSD, and 15.6-inch 4K display.",
            ImageFile = "product-6",
            Price = 1799.00M,
            Category = new List<string>{ "Electronics", "Computers" }
        },
        new Product()
        {
            Id = new Guid("b2c3d4e5-6789-4321-9abc-abcdef123456"),
            Name = "KitchenAid Stand Mixer",
            Description = "Iconic stand mixer with 5-quart stainless steel bowl and multiple attachments for baking and cooking.",
            ImageFile = "product-7",
            Price = 449.99M,
            Category = new List<string>{ "Home", "Kitchen Appliances" }
        },
        new Product()
        {
            Id = new Guid("c3d4e5f6-7890-4321-9abc-fedcba654321"),
            Name = "LEGO Star Wars Millennium Falcon",
            Description = "Highly detailed LEGO building set of the iconic Millennium Falcon with over 7,500 pieces.",
            ImageFile = "product-8",
            Price = 849.99M,
            Category = new List<string>{ "Toys", "Collectibles" }
        },
        new Product()
        {
            Id = new Guid("d4e5f6a7-8901-4321-9abc-1234abcdef56"),
            Name = "Fitbit Charge 6",
            Description = "Advanced fitness tracker with heart rate monitoring, GPS, and sleep tracking features.",
            ImageFile = "product-9",
            Price = 159.95M,
            Category = new List<string>{ "Electronics", "Wearables" }
        },
        new Product()
        {
            Id = new Guid("e5f6a7b8-9012-4321-9abc-abcdef654321"),
            Name = "Dyson V15 Detect Vacuum Cleaner",
            Description = "Cordless vacuum cleaner with laser dust detection and powerful suction for deep cleaning.",
            ImageFile = "product-10",
            Price = 749.99M,
            Category = new List<string>{ "Home", "Cleaning Appliances" }
        }
    };

        return products;
    }

}

