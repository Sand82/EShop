namespace Ordering.Application.Orders.EventHandlers;

public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handler: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}
