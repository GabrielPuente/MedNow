using MedNow.Domain.Entities;

namespace MedNow.Infra.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(Guid id);
    }
}
