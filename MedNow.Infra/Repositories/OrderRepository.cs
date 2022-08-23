using MedNow.Domain.Contracts.Repositories;
using MedNow.Domain.Entities;
using MedNow.Infra.Auditing;

namespace MedNow.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IEntryAuditor _entryAuditor;

        public OrderRepository(DataContext context, IEntryAuditor entryAuditor)
        {
            _context = context;
            _entryAuditor = entryAuditor;
        }

        public async Task CreateOrder(Order order)
        {
            _entryAuditor.AuditCreate(_context.Entry(order));
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
