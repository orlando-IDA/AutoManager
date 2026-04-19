using AutoManager.Application.DTOs;

namespace AutoManager.Application.Services;

public interface IVehicleRepository
{
    IReadOnlyList<VehicleResponse> GetAll();
    IReadOnlyList<VehicleResponse> GetByCustomerId(Guid customerId);
    VehicleResponse? GetById(Guid id);
    VehicleResponse Create(VehicleRequest request);
    bool ExistsByLicensePlate(string licensePlate);
    bool Delete(Guid id);
}