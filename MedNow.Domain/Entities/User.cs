using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MedNow.Domain.DefaultEntity;

namespace MedNow.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public DateTime BirthDate { get; private set; }

        public string Cpf { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Role { get; private set; }

        protected User()
        {
        }

        public User(string name, DateTime birthDate, string cpf, string email, string password, string role)
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Email = email;
            Password = password;
            Role = role;

            CheckDomainIsValid();
        }

        private void CheckDomainIsValid()
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
