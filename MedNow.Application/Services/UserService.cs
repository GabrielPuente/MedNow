using MedNow.Application.AuthenticationService;
using MedNow.Domain.Commands;
using MedNow.Domain.Commands.User;
using MedNow.Infra.Contracts.Repositories;
using MedNow.Application.Contracts.Services;
using MedNow.Domain.Entities;
using System.Threading.Tasks;

namespace MedNow.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse<User>> CreateUser(CreateUserCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResponse<User>(null, command.Notifications);
            }

            var password = PasswordService.Encrypt(command.Password);

            var user = new User(command.Name, command.BirthDate, command.Cpf, command.Email, password, command.Role);

            if (!user.IsValid)
            {
                return new CommandResponse<User>(null, user.Notifications);
            }

            await _repository.CreateUser(user);

            return new CommandResponse<User>(user, user.Notifications);
        }

        public async Task<CommandResponse<User>> LoginUser(LoginUserCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResponse<User>(null, command.Notifications);
            }

            var user = await _repository.GetByEmail(command.Email);

            if (user is null)
            {
                command.AddNotification("User", "Login ou senha invalida");
                return new CommandResponse<User>(null, command.Notifications);
            }

            var areEqual = PasswordService.CheckPassword(command.Password, user.Password);

            if (!areEqual)
            {
                command.AddNotification("User", "Login ou senha invalida");
                return new CommandResponse<User>(null, command.Notifications);
            }

            return new CommandResponse<User>(user, user.Notifications);
        }
    }
}
