using Flunt.Notifications;
using Flunt.Validations;

namespace MedNow.Application.Commands.User
{
    public class LoginUserCommand : Command
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                  .IsEmail(Email, "Email", "Email invalido")
                  .IsNotNullOrEmpty(Password, "Password", "Senha é obrigatorio"));
        }
    }
}
