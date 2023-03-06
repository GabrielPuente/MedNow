using MedNow.Infra.Contracts.Repositories;
using MedNow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedNow.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
