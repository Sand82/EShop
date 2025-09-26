﻿namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);

internal class GetBasketQueryHandler() : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
       //TODO:get basket from database
       //var basket = await repository.GetBasket(request.UserName);

        return new GetBasketResult(new ShoppingCart("Sand"));
    }
}
