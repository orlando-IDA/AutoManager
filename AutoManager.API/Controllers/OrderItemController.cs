using Microsoft.AspNetCore.Mvc;
using AutoManager.Application.DTOs;
using AutoManager.Application.Services;

namespace AutoManager.API.Controllers;

/// <summary>
/// Controller responsável pelas peças e serviços de uma ordem de serviço.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class 
    OrderItemController(IOrderItemRepository orderItemRepository) : ControllerBase
{
    /// <summary>
    /// Lista todos os itens de uma ordem de serviço.
    /// </summary>
    [HttpGet("order/{serviceOrderId:guid}")]
    public IActionResult GetByOrder(Guid serviceOrderId)
    {
        var items = orderItemRepository.GetByServiceOrderId(serviceOrderId);
        return Ok(items);
    }

    /// <summary>
    /// Adiciona um novo item (peça ou serviço) a uma ordem de serviço.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] OrderItemRequest request)
    {
        try
        {
            var item = orderItemRepository.Create(request);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove um item pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!orderItemRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}