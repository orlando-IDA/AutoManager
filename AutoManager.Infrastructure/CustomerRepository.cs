using AutoManager.Application.DTOs;
using AutoManager.Application.Services;
using AutoManager.Infrastructure.Persistence;

namespace AutoManager.Infrastructure;

public sealed class CustomerRepository(AutoManagerContext context) : ICustomerRepository
{
    public IReadOnlyList<CustomerResponse> GetAll()
    {
        return context.Customers
            .OrderBy(c => c.Name)
            .Select(CustomerResponse.FromDomain)
            .ToList();
    }

    public CustomerResponse? GetById(Guid id)
    {
        var customer = context.Customers
            .FirstOrDefault(c => c.Id == id);

        return customer is null ? null : CustomerResponse.FromDomain(customer);
    }

    public CustomerResponse Create(CustomerRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        if (ExistsByCpf(request.cpf))
            throw new InvalidOperationException("Já existe um cliente com este CPF");

        var customer = request.ToDomain();

        context.Customers.Add(customer);
        context.SaveChanges();

        return CustomerResponse.FromDomain(customer);
    }

    public bool ExistsByCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf)) return false;
        
        var normalizedCpf = cpf.Trim();
        return context.Customers.Any(c => c.Cpf == normalizedCpf);
    }

    public bool ExistsById(Guid id)
    {
        return context.Customers.Any(c => c.Id == id);
    }

    public bool Delete(Guid id)
    {
        var customer = context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer is null) return false;

        context.Customers.Remove(customer);
        context.SaveChanges();

        return true;
    }
}