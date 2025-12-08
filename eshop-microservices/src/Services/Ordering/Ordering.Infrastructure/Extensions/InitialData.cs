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
}
