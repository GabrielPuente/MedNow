using MedNow.Domain.Entities;

namespace MedNow.Infra.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);

        Task<User> GetByEmail(string email);
        
        Task<User> GetById(Guid Id);
    }
}
