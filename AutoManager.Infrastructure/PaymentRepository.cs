using AutoManager.Application.DTOs;
using AutoManager.Application.Services;
using AutoManager.Infrastructure.Persistence;

namespace AutoManager.Infrastructure;

public sealed class PaymentRepository(AutoManagerContext context) : IPaymentRepository
{
    public PaymentResponse? GetByServiceOrderId(Guid serviceOrderId)
    {
        var payment = context.Payments.FirstOrDefault(p => p.ServiceOrderId == serviceOrderId);
        return payment is null ? null : PaymentResponse.FromDomain(payment);
    }

    public PaymentResponse Create(PaymentRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        // Garantir que a Ordem de Serviço existe e não tem pagamento
        var order = context.ServiceOrders.FirstOrDefault(so => so.Id == request.serviceOrderId);
        if (order is null) throw new InvalidOperationException("Ordem de Serviço não encontrada");
        
        var existingPayment = context.Payments.Any(p => p.ServiceOrderId == request.serviceOrderId);
        if (existingPayment) throw new InvalidOperationException("Esta Ordem de Serviço já possui um pagamento");

        var payment = request.ToDomain();

        context.Payments.Add(payment);
        context.SaveChanges();

        return PaymentResponse.FromDomain(payment);
    }
}