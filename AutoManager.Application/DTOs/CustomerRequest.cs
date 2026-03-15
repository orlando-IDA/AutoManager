using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record CustomerRequest(
    [Required(ErrorMessage = "The Field Name is Required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters long.")]
    string Name,

    [Required(ErrorMessage = "The Field CPF is Required.")]
    [StringLength(14, MinimumLength = 11, ErrorMessage = "CPF must be between 11 and 14 characters long.")]
    string Cpf,
    
    string? Phone
)
{
    public Customer ToDomain() => new Customer(
        Name,
        Cpf,
        Phone
    );
}