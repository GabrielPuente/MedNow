using MedNow.Domain.DefaultEntity;

namespace MedNow.Infra.Contracts
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll(bool trackEntities = true);

        Task<T> GetById(Guid id, bool trackEntities = true);

        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task Commit();

        Task Rollback();
    }
}
