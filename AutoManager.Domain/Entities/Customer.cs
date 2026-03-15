using AutoManager.Domain.Common;

namespace AutoManager.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public string? Phone { get; private set; } // Opcional
    
    public List<Vehicle> Vehicles { get; private set; } = new();

    public Customer(string name, string cpf, string? phone)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new Exception("The customer's name cannot be empty.");
            
        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length < 11) 
            throw new Exception("Invalid CPF.");

        Name = name;
        Cpf = cpf;
        Phone = phone;
    }
}