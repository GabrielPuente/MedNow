using MedNow.Domain.DefaultEntity;

namespace MedNow.Infra.Contracts
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll(bool trackEntities = true);

        Task<T> GetById(Guid id, bool trackEntities = true);

        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

        Task Delete(T entity);

        Task SaveChanges();
    }
}
