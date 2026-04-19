using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;
using AutoManager.Domain.Enums;

namespace AutoManager.Application.DTOs;

public record ServiceOrderRequest(
    [Required(ErrorMessage = "A data de entrada é obrigatória")]
    DateTime entryDate,

    [Required(ErrorMessage = "O ID do veículo é obrigatório")]
    Guid vehicleId
)
{
    public ServiceOrder ToDomain() => new ServiceOrder(
        entryDate,
        vehicleId
    );
}