using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record OrderItemRequest(
    [property: Required(ErrorMessage = "A descrição é obrigatória")]
    [property: StringLength(100, MinimumLength = 3, ErrorMessage = "A descrição deve ter entre 3 e 100 caracteres")]
    string description,

    [property: Required(ErrorMessage = "O preço é obrigatório")]
    [property: Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero")]
    decimal price,

    [property: Required(ErrorMessage = "O ID da Ordem de Serviço é obrigatório")]
    Guid serviceOrderId
)
{
    public OrderItem ToDomain() => new OrderItem(
        description,
        price,
        serviceOrderId
    );
}