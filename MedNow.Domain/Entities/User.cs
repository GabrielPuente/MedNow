using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MedNow.Domain.DefaultEntity;
using MedNow.Domain.ValueObjects;

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

        public Address Address { get; private set; }

        public CreditCard CreditCard { get; private set; }

        protected User()
        {
        }

        public User(string name, DateTime birthDate, string cpf, string email, string password, string role, CreditCard creditCard, Address address)
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Email = email;
            Password = password;
            Role = role;

            CreditCard = creditCard;
            Address = address;

            CreditCard.SetUserId(Id);
            Address.SetUserId(Id);

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
                  .IsGreaterThan(BirthDate, DateTime.MinValue, "BirthDate", "Campo data de nascimento invalida")
                  .IsNotNullOrEmpty(Address.ZipCode, "ZipCode", "CEP é obrigatorio")
                  .IsNotNullOrEmpty(Address.Street, "Street", "Rua é obrigatorio")
                  .IsNotNullOrEmpty(Address.Neighborhood, "Neighborhood", "Bairro é obrigatorio")
                  .IsNotNullOrEmpty(Address.City, "City", "Cidade é obrigatorio")
                  .IsNotNullOrEmpty(Address.State, "State", "Estado é obrigatorio")
                  .IsGreaterThan(Address.Number, 0, "Number", "Numero é obrigatorio")
                  .IsNotNullOrEmpty(CreditCard.Name, "name", "Nome do cartao é obrigatorio")
                  .IsGreaterThan(CreditCard.Number, 0, "Number", "Numero do cartao é obrigatorio")
                  .IsGreaterThan(CreditCard.ExpirationDate, DateTime.MinValue, "ExpirationDate", "Data de validade do cartao é obrigatorio")
                  .IsGreaterThan(CreditCard.Cvv, 0, "CVV", "Campo é obrigatorio"));
        }
    }
}
