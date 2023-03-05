using MedNow.Domain.Entities;

namespace MedNow.Infra.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
    }
}
