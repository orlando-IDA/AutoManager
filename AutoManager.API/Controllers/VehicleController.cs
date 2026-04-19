using Microsoft.AspNetCore.Mvc;
using AutoManager.Application.DTOs;
using AutoManager.Application.Services;

namespace AutoManager.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de veículos na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleController(IVehicleRepository vehicleRepository) : ControllerBase
{
    /// <summary>
    /// Lista todos os veículos cadastrados.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var vehicles = vehicleRepository.GetAll();
        return Ok(vehicles);
    }

    /// <summary>
    /// Busca veículos de um cliente específico.
    /// </summary>
    [HttpGet("customer/{customerId:guid}")]
    public IActionResult GetByCustomer(Guid customerId)
    {
        var vehicles = vehicleRepository.GetByCustomerId(customerId);
        return Ok(vehicles);
    }

    /// <summary>
    /// Busca um veículo pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var vehicle = vehicleRepository.GetById(id);
        if (vehicle is null)
            return NotFound();

        return Ok(vehicle);
    }

    /// <summary>
    /// Cadastra um novo veículo.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] VehicleRequest request)
    {
        try
        {
            var vehicle = vehicleRepository.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = vehicle.id }, vehicle);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove um veículo pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!vehicleRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}