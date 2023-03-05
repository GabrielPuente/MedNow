using MedNow.Domain.Entities;
using System.Threading.Tasks;

namespace MedNow.Infra.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
    }
}
