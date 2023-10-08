using MedNow.Domain.DefaultEntity;
using MedNow.Infra.Auditing;
using MedNow.Infra.Constants;
using MedNow.Infra.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MedNow.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _set;
        protected readonly IEntryAuditor _entryAuditor;

        public BaseRepository(DataContext context, IEntryAuditor entryAuditor)
        {
            _context = context;
            _set = context.Set<T>();
            _entryAuditor = entryAuditor;
        }

        public virtual async Task<IEnumerable<T>> GetAll(bool trackEntities = true)
        {
            if (trackEntities)
            {
                return await _set
                    .Where(x => !EF.Property<bool>(x, "IsDeleted"))
                    .ToListAsync();
            }

            return await _set
                .Where(x => !EF.Property<bool>(x, "IsDeleted"))
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id, bool trackEntities = true)
        {
            IQueryable<T> query = null;
            query = trackEntities ? _set : _set.AsNoTracking();

            return await query
                .Where(x => !EF.Property<bool>(x, "IsDeleted"))
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task Add(T entity)
        {
            _entryAuditor.AuditCreate(_context.Entry(entity));
            await _set.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _entryAuditor.AuditUpdate(_context.Entry(entity));
            _set.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            var entityEntry = _context.Entry(entity);

            entityEntry.Property(Columns.IS_DELETED).CurrentValue = true;

            _entryAuditor.AuditDelete(entityEntry);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Rollback()
        {
        }
    }
}
