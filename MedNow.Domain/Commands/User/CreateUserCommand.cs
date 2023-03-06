using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;

namespace MedNow.Domain.Commands.User
{
    public class CreateUserCommand : Command
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                  .IsNotNullOrEmpty(Name, "Name", "Campo nome é obrigatorio")
                  .IsEmail(Email, "Email", "Email invalido")
                  .IsCpf(Cpf, "Cpf", "Cpf invalido")
                  .IsNotNullOrEmpty(Password, "Password", "Senha é obrigatorio")
                  .IsNotNullOrEmpty(Role, "Role", "Campo cargo é obrigatorio")
                  .IsGreaterThan(BirthDate, DateTime.MinValue, "BirthDate", "Campo data de nascimento invalida"));
        }
    }
}
