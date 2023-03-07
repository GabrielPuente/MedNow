using MedNow.Domain.Entities;
using MedNow.Infra.Contracts;
using MedNow.Infra.Auditing;

namespace MedNow.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext ctx, IEntryAuditor entryAuditor) : base(ctx, entryAuditor)
        {
        }
    }
}
