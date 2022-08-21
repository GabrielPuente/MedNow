using MedNow.Domain.Entities;

namespace MedNow.Domain.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
    }
}
