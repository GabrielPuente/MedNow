using MedNow.Domain.Commands;
using MedNow.Domain.Commands.Order;
using MedNow.Domain.Entities;
using System.Threading.Tasks;

namespace MedNow.Application.Contracts.Services
{
    public interface IOrderService
    {
        Task<CommandResponse<Order>> CreateOrder(CreateOrderCommand command);
    }
}
