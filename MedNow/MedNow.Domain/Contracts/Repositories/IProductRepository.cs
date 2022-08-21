using MedNow.Domain.Entities;

namespace MedNow.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(Guid id);
    }
}
