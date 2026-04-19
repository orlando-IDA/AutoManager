using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;
using AutoManager.Domain.Enums;

namespace AutoManager.Application.DTOs;

public record PaymentRequest(
    [Required(ErrorMessage = "O valor total é obrigatório")]
    [Range(0.01, 999999.99, ErrorMessage = "O valor deve ser maior que zero")]
    decimal totalAmount,

    [Required(ErrorMessage = "O método de pagamento é obrigatório")]
    PaymentMethodEnum method,

    [Required(ErrorMessage = "O ID da Ordem de Serviço é obrigatório")]
    Guid serviceOrderId
)
{
    public Payment ToDomain() => new Payment(totalAmount, method, serviceOrderId);
}