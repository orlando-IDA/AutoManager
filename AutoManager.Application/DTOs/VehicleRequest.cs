using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record VehicleRequest(
    [Required(ErrorMessage = "The Field License Plate is Required.")]
    [StringLength(8, MinimumLength = 7, ErrorMessage = "License  Plate must be 8 characters long.")]
    string LicensePlate,

    [Required(ErrorMessage = "The Field Manufacturer is Required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Manufacturer must be 2-50 characters long.")]
    string Manufacturer,

    [Required(ErrorMessage = "The field Model is Required.")]
    string Model,

    [Required(ErrorMessage = "The field Customer(ID) is Required.")]
    int CustomerId
)
{
    public Vehicle ToDomain() => new Vehicle(
        LicensePlate,
        Manufacturer,
        Model,
        CustomerId
    );
}