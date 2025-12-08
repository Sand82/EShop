namespace Ordering.Infrastructure.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers()
    {
        return new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("1f4f26e4-a043-4f5c-9b0b-643483e74ccc")), "Sand", "sand@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("f5bf8ea3-6e14-451b-977d-61ba9e4c10a9")), "Mish", "mish@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("bfacf772-7cb5-469e-a6ef-72c43281a958")), "Lub", "lub@gmail.com")
        };        
    }

    public static IEnumerable<Product> Products()
    {
        return new List<Product> 
        { 
            Product.Create(ProductId.Of(new Guid("4b2af7e6-2155-4d43-8067-44642e383678")), "I Phone", 500),
            Product.Create(ProductId.Of(new Guid("a1807a73-16a3-445d-8180-5d90d3bcb49a")), "Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("a2372a3a-7593-47ac-967b-52ee1f72f5ba")), "Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("0188f95e-771a-4d27-b922-618602821e9f")), "Xiaomi Mi", 450)
        };
    }

    public static IEnumerable<Order> OrdersWhitItems
    {
        get
        {
            var address1 = Address.Of("sand", "stef", "sand@gmail.com", "test", "Bulgaria", "Sofia", "1220");
            var address2 = Address.Of("mish", "stef", "mish@gmail.com", "test1", "Bulgaria", "Sofia", "1220");

            var payment1 = Payment.Of("sand", "32432432454", "12/20", "355", 1);
            var payment2 = Payment.Of("mish", "546575675", "16/30", "278", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("1f4f26e4-a043-4f5c-9b0b-643483e74ccc")),
                OrderName.Of("Order 1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);

            order1.Add(ProductId.Of(new Guid("4b2af7e6-2155-4d43-8067-44642e383678")), 2, 500);
            order1.Add(ProductId.Of(new Guid("a1807a73-16a3-445d-8180-5d90d3bcb49a")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("f5bf8ea3-6e14-451b-977d-61ba9e4c10a9")),
                OrderName.Of("Order 2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);

            order2.Add(ProductId.Of(new Guid("a2372a3a-7593-47ac-967b-52ee1f72f5ba")), 1, 650);
            order2.Add(ProductId.Of(new Guid("0188f95e-771a-4d27-b922-618602821e9f")), 1, 450);

            return new List<Order> { order1, order2 };  
        }
    }
}
