using MedNow.Application.Commands;
using MedNow.Application.Commands.Order;
using MedNow.Domain.Entities;

namespace MedNow.Application.Contracts.Services
{
    public interface IOrderService
    {
        Task<CommandResponse<Order>> CreateOrder(CreateOrderCommand command);
    }
}
