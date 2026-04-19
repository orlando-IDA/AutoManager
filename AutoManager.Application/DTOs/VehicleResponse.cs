using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record VehicleResponse(Guid id, string licensePlate, string manufacturer, string model, Guid customerId)
{
    public static VehicleResponse FromDomain(Vehicle vehicle) => 
        new(vehicle.Id, vehicle.LicensePlate, vehicle.Manufacturer, vehicle.Model, vehicle.CustomerId);
}