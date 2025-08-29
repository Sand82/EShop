
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GeProductById
{
    public record GetProductByIdResponce(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                var responce = result.Adapt<GetProductByIdResponce>();

                return Results.Ok(responce);
            })
            .WithName("GetProductById")
            .Produces<GetProductsResponce>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
        }
    }
}
