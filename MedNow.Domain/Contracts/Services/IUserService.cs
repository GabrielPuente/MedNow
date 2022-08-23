using MedNow.Domain.Commands;
using MedNow.Domain.Commands.User;
using MedNow.Domain.Entities;
using System.Threading.Tasks;

namespace MedNow.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<CommandResponse<User>> CreateUser(CreateUserCommand command);

        Task<CommandResponse<User>> LoginUser(LoginUserCommand command);
    }
}
