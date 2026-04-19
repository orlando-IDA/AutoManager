using AutoManager.Application.DTOs;
using AutoManager.Application.Services;
using AutoManager.Infrastructure.Persistence;

namespace AutoManager.Infrastructure;

public sealed class VehicleRepository(AutoManagerContext context) : IVehicleRepository
{
    public IReadOnlyList<VehicleResponse> GetAll()
    {
        return context.Vehicles
            .OrderBy(v => v.LicensePlate)
            .Select(VehicleResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<VehicleResponse> GetByCustomerId(Guid customerId)
    {
        return context.Vehicles
            .Where(v => v.CustomerId == customerId)
            .Select(VehicleResponse.FromDomain)
            .ToList();
    }

    public VehicleResponse? GetById(Guid id)
    {
        var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == id);
        return vehicle is null ? null : VehicleResponse.FromDomain(vehicle);
    }

    public VehicleResponse Create(VehicleRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        if (ExistsByLicensePlate(request.licensePlate))
            throw new InvalidOperationException("Já existe um veículo com esta placa");

        var vehicle = request.ToDomain();

        context.Vehicles.Add(vehicle);
        context.SaveChanges();

        return VehicleResponse.FromDomain(vehicle);
    }

    public bool ExistsByLicensePlate(string licensePlate)
    {
        if (string.IsNullOrWhiteSpace(licensePlate)) return false;
        return context.Vehicles.Any(v => v.LicensePlate == licensePlate.Trim());
    }

    public bool Delete(Guid id)
    {
        var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle is null) return false;

        context.Vehicles.Remove(vehicle);
        context.SaveChanges();

        return true;
    }
}