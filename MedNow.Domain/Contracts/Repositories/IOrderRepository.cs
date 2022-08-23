using MedNow.Domain.Entities;
using System.Threading.Tasks;

namespace MedNow.Domain.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
    }
}
