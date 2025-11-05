namespace Ordering.Domain.Abstractions;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new(); 
    public IReadOnlyList<IDomainEvent> DomainEvents => throw new NotImplementedException();

    public void AddIDomainEvents(IDomainEvent domainEvents)
    {
        _domainEvents.Add(domainEvents);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedEvents = _domainEvents.ToArray();

        _domainEvents.Clear();

        return dequeuedEvents;
    }
}
