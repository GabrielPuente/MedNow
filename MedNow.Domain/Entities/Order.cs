using Flunt.Notifications;
using Flunt.Validations;
using MedNow.Domain.DefaultEntity;

namespace MedNow.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public User User { get; private set; }

        public decimal TotalValue { get; private set; }

        private readonly List<OrderItem> _orderItem = new();

        public virtual IReadOnlyList<OrderItem> OrderItems => _orderItem.AsReadOnly();

        protected Order()
        {
        }

        public Order(User user)
        {
            User = user;
            CheckDomainIsValid();
        }

        protected override void CheckDomainIsValid()
        {
            AddNotifications(new Contract<Notification>()
                  .IsGreaterOrEqualsThan(OrderItems.Count, 1, "Itens", "Itens no carrinho deve ser maior que 1"));
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
