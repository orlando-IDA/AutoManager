using AutoManager.Domain.Entities;
using AutoManager.Domain.Enums;

namespace AutoManager.Application.DTOs;

public record PaymentResponse(Guid id, decimal totalAmount, PaymentMethodEnum method, Guid serviceOrderId)
{
    public static PaymentResponse FromDomain(Payment payment) => 
        new(payment.Id, payment.TotalAmount, payment.Method, payment.ServiceOrderId);
}