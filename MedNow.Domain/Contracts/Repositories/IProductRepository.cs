using MedNow.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MedNow.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(Guid id);
    }
}
