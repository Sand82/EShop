namespace Basket.API.Basket.DeleteBasket;

public record DelateBasketCommand(string UserName) : ICommand<DelateBasketResult>;
public record DelateBasketResult(bool IsSuccess);

public class DelateBasketCommandValidator : AbstractValidator<DelateBasketCommand>
{
    public DelateBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required.");
    }
}

public class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DelateBasketCommand, DelateBasketResult>
{
    public async Task<DelateBasketResult> Handle(DelateBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(command.UserName, cancellationToken);

        return new DelateBasketResult(true);
    }
}