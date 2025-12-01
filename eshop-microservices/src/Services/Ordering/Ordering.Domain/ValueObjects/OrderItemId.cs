namespace Ordering.Domain.ValueObjects;

public record OrderItemId
{
    public OrderItemId(Guid guid)
    {
        Value = guid;
    }

    public Guid Value { get; }

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrderItemId cannot be empty.");
        }

        return new OrderItemId(value);
    }
}
