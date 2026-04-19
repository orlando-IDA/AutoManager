using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record CustomerRequest(
    [property: Required(ErrorMessage = "O nome é obrigatório")]
    [property: StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
    string name,

    [property: Required(ErrorMessage = "O CPF é obrigatório")]
    [property: StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve ter entre 11 e 14 caracteres")]
    string cpf,
    
    string? phone
)
{
    public Customer ToDomain() => new Customer(
        name,
        cpf,
        phone
    );
}