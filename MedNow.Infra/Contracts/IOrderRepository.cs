using MedNow.Domain.Entities;

namespace MedNow.Infra.Contracts
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
    }
}
