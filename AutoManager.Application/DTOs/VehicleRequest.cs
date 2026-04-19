using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record VehicleRequest(
    [Required(ErrorMessage = "A placa é obrigatória")]
    [StringLength(10, MinimumLength = 7, ErrorMessage = "A placa deve ter entre 7 e 10 caracteres")]
    string licensePlate,

    [Required(ErrorMessage = "A montadora é obrigatória")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "A montadora deve ter entre 2 e 50 caracteres")]
    string manufacturer,

    [Required(ErrorMessage = "O modelo é obrigatório")]
    string model,

    [Required(ErrorMessage = "O ID do cliente é obrigatório")]
    Guid customerId
)
{
    public Vehicle ToDomain() => new Vehicle(
        licensePlate,
        manufacturer,
        model,
        customerId
    );
}