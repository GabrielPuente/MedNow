using Flunt.Notifications;
using Flunt.Validations;

namespace MedNow.Domain.Commands.Order
{
    public class CreateOrderCommand : Command
    {
        public Guid UserId { get; set; }

        public AddressCommand Address { get; set; }

        public CreditCardCommand CreditCard { get; set; }

        public List<ProductCommand> Products { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                 .IsNotNullOrEmpty(Address.ZipCode, "ZipCode", "CEP é obrigatorio")
                 .IsNotNullOrEmpty(Address.Street, "Street", "Rua é obrigatorio")
                 .IsNotNullOrEmpty(Address.Neighborhood, "Neighborhood", "Bairro é obrigatorio")
                 .IsNotNullOrEmpty(Address.City, "City", "Cidade é obrigatorio")
                 .IsNotNullOrEmpty(Address.State, "State", "Estado é obrigatorio")
                 .IsGreaterThan(Address.Number, 0, "Number", "Numero é obrigatorio")
                 .IsNotNullOrEmpty(CreditCard.Name, "name", "Nome do cartao é obrigatorio")
                 .IsGreaterThan(CreditCard.Number, 0, "Number", "Numero do cartao é obrigatorio")
                 .IsGreaterThan(CreditCard.ExpirationDate, DateTime.MinValue, "ExpirationDate", "Data de validade do cartao é obrigatorio")
                 .IsGreaterThan(CreditCard.Cvv, 0, "CVV", "Campo é obrigatorio")
                 .IsGreaterThan(Products.Count, 0, "Products", "Precisa selecionar pelo menos um produto"));
        }
    }

    public class ProductCommand
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }
    }


    public class AddressCommand
    {
        public string ZipCode { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    }

    public class CreditCardCommand
    {
        public long Number { get; set; }

        public string Name { get; set; }

        public int Cvv { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
