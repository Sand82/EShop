namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    public ProductId(Guid guid)
    {
        Value = guid;
    }
    public Guid Value { get; }

    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("ProductId cannot be empty.");
        }

        return new ProductId(value);
    }
}
