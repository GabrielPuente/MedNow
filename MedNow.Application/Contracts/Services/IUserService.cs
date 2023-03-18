using MedNow.Application.Commands;
using MedNow.Application.Commands.User;
using MedNow.Domain.Entities;

namespace MedNow.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<CommandResponse<User>> CreateUser(CreateUserCommand command);

        Task<CommandResponse<User>> LoginUser(LoginUserCommand command);
    }
}
