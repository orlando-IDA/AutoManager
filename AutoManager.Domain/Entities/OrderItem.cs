using AutoManager.Domain.Common;

namespace AutoManager.Domain.Entities;

public class OrderItem : BaseEntity
{
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    public Guid ServiceOrderId { get; private set; }
    public ServiceOrder ServiceOrder { get; private set; } = null!;

    public OrderItem(string description, decimal price, Guid serviceOrderId)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new Exception("The description cannot be empty.");

        if (price <= 0)
            throw new Exception("The price must be greater than zero.");

        Description = description;
        Price = price;
        ServiceOrderId = serviceOrderId;
    }
}