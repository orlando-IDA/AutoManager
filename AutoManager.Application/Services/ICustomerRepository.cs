using AutoManager.Application.DTOs;

namespace AutoManager.Application.Services;

public interface ICustomerRepository
{
    IReadOnlyList<CustomerResponse> GetAll();
    CustomerResponse? GetById(Guid id);
    CustomerResponse Create(CustomerRequest request);
    bool ExistsByCpf(string cpf);
    bool ExistsById(Guid id);
    bool Delete(Guid id);
}