using Microsoft.AspNetCore.Mvc;
using AutoManager.Application.DTOs;
using AutoManager.Application.Services;

namespace AutoManager.API.Controllers;

/// <summary>
/// Controller responsável pelo pagamento das ordens de serviço.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PaymentController(IPaymentRepository paymentRepository) : ControllerBase
{
    /// <summary>
    /// Busca o pagamento de uma ordem de serviço específica.
    /// </summary>
    [HttpGet("order/{serviceOrderId:guid}")]
    public IActionResult GetByOrder(Guid serviceOrderId)
    {
        var payment = paymentRepository.GetByServiceOrderId(serviceOrderId);
        if (payment is null) return NotFound();
        return Ok(payment);
    }

    /// <summary>
    /// Realiza o pagamento de uma ordem de serviço.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] PaymentRequest request)
    {
        try
        {
            var payment = paymentRepository.Create(request);
            return Ok(payment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}