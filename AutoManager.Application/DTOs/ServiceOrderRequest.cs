using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;
using AutoManager.Domain.Enums;

namespace AutoManager.Application.DTOs;

public record ServiceOrderRequest(
    [Required(ErrorMessage = "The field Date is required.")]
    DateTime EntryDate,

    [Required(ErrorMessage = "The field Status is required.")]
    ServiceOrderStatusEnum Status,

    [Required(ErrorMessage = "The field Vehicle is required.")]
    int VehicleId
)
{
    public ServiceOrder ToDomain() => new ServiceOrder(
        EntryDate,
        Status,
        VehicleId
    );
}