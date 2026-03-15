using System.ComponentModel.DataAnnotations;
using AutoManager.Domain.Entities;

namespace AutoManager.Application.DTOs;

public record OrderItemRequest(
    [Required(ErrorMessage = "The Field 'Description' is Required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 characters long.")]
    string Description,

    [Required(ErrorMessage = "Field 'Price' is Required.")]
    [Range(0.01, 999999.99, ErrorMessage = "The Price must be greater than zero")]
    decimal Price,

    [Required(ErrorMessage = "The Field 'ServiceOrderId' is Required.")]
    int ServiceOrderId
)
{
    public OrderItem ToDomain() => new OrderItem(
        Description,
        Price,
        ServiceOrderId
    );
}