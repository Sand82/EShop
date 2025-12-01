namespace Ordering.Domain.ValueObjects;

public record OrderId
{
    public OrderId(Guid guid)
    {
        Value = guid;
    }

    public Guid Value { get; }

    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrderId cannot be empty.");
        }

        return new OrderId(value);
    }
}
