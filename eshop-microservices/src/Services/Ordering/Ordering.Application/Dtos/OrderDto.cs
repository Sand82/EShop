using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public record OrdeDto(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemsDto> OrderItems);