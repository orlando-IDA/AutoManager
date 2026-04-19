using AutoManager.Domain.Common;
using AutoManager.Domain.Enums;

namespace AutoManager.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal TotalAmount { get; private set; }
    
    public PaymentMethodEnum Method { get; private set; }

    public Guid ServiceOrderId { get; private set; }
    public ServiceOrder ServiceOrder { get; private set; } = null!;

    public Payment(decimal totalAmount, PaymentMethodEnum method, Guid serviceOrderId)
    {
        if (totalAmount <= 0)
            throw new Exception("The total amount must be greater than zero.");

        TotalAmount = totalAmount;
        Method = method;
        ServiceOrderId = serviceOrderId;
    }
}