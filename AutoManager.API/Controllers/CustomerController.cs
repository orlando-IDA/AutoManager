using Microsoft.AspNetCore.Mvc;
using AutoManager.Application.DTOs;
using AutoManager.Application.Services;

namespace AutoManager.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de clientes na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    /// <summary>
    /// Lista todos os clientes cadastrados.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = customerRepository.GetAll();
        return Ok(customers);
    }

    /// <summary>
    /// Busca um cliente pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var customer = customerRepository.GetById(id);
        if (customer is null)
            return NotFound();

        return Ok(customer);
    }

    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] CustomerRequest request)
    {
        try
        {
            var customer = customerRepository.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = customer.id }, customer);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove um cliente pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!customerRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}