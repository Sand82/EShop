using Basket.API.Basket.StoreBasket;

namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketRequest(string UserName);
public record DelateBasketResponse(bool IsSuccess);

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender ) =>
        {
            var result = await sender.Send( new DeleteBasketRequest(userName));

            var response = result.Adapt<DelateBasketResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteBasket")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basket")
        .WithDescription("Delete Basket");
    }
}
