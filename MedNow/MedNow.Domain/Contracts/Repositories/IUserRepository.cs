using MedNow.Domain.Entities;

namespace MedNow.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);

        Task<User> GetByEmail(string email);
    }
}
