using Flunt.Notifications;
using Flunt.Validations;
using MedNow.Domain.DefaultEntity;
using MedNow.Domain.ValueObjects;

namespace MedNow.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public User User { get; private set; }

        public decimal TotalValue { get; private set; }

        public Address Address { get; private set; }

        public CreditCard CreditCard { get; private set; }

        private readonly List<OrderItem> _orderItem = new();

        public virtual IReadOnlyList<OrderItem> OrderItems => _orderItem.AsReadOnly();

        protected Order()
        {

        }

        public Order(User user, CreditCard creditCard, Address address)
        {
            User = user;
            CreditCard = creditCard;
            Address = address;

            CreditCard.SetOrderId(Id);
            Address.SetOrderId(Id);

            CheckDomainIsValid();
        }

        private void CheckDomainIsValid()
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
                  .IsGreaterThan(CreditCard.Cvv, 0, "CVV", "Campo é obrigatorio"));
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItem.Add(orderItem);
            CalculateTotalValue();
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            _orderItem.Remove(orderItem);
        }

        private void CalculateTotalValue()
        {
            TotalValue = _orderItem.Sum(x => x.TotalValue);
        }
    }
}
