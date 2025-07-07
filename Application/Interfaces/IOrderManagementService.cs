// practice_0502025.Application.Interfaces/IOrderManagementService.cs
using practice_0502025.Application.DTOs; // Assuming your DTOs
using System.Threading.Tasks;

namespace practice_0502025.Application.Interfaces
{
    public interface IOrderManagementService
    {
        Task<OrderDto> PlaceOrderAsync(CreateOrderDto orderDto);
        // Add other specific order-related operations here, e.g.,
        // Task<bool> CancelOrderAsync(int orderId);
    }
}