using Microsoft.AspNetCore.Mvc;
using AutoManager.Application.DTOs;
using AutoManager.Application.Services;
using AutoManager.Domain.Enums;

namespace AutoManager.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de ordens de serviço na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ServiceOrderController(IServiceOrderRepository serviceOrderRepository) : ControllerBase
{
    /// <summary>
    /// Lista todas as ordens de serviço cadastradas.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = serviceOrderRepository.GetAll();
        return Ok(orders);
    }

    /// <summary>
    /// Busca ordens de serviço de um veículo específico.
    /// </summary>
    [HttpGet("vehicle/{vehicleId:guid}")]
    public IActionResult GetByVehicle(Guid vehicleId)
    {
        var orders = serviceOrderRepository.GetByVehicleId(vehicleId);
        return Ok(orders);
    }

    /// <summary>
    /// Busca uma ordem de serviço pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var order = serviceOrderRepository.GetById(id);
        if (order is null)
            return NotFound();

        return Ok(order);
    }

    /// <summary>
    /// Abre uma nova ordem de serviço.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] ServiceOrderRequest request)
    {
        try
        {
            var order = serviceOrderRepository.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = order.id }, order);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza o status de uma ordem de serviço.
    /// </summary>
    [HttpPatch("{id:guid}/status")]
    public IActionResult UpdateStatus(Guid id, [FromBody] ServiceOrderStatusEnum status)
    {
        if (!serviceOrderRepository.UpdateStatus(id, status))
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Remove uma ordem de serviço pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!serviceOrderRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}