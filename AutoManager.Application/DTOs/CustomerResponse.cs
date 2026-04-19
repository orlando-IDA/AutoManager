using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record CustomerResponse(Guid id, string name, string cpf, string? phone)
{
    public static CustomerResponse FromDomain(Customer customer) => 
        new(customer.Id, customer.Name, customer.Cpf, customer.Phone);
}