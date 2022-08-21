using MedNow.Domain.DefaultEntity;

namespace MedNow.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public User User { get; set; }

        private readonly List<OrderItem> _orderItem = new();

        public virtual IReadOnlyList<OrderItem> OrderItems => _orderItem.AsReadOnly();

        protected Order()
        {

        }

        public Order(User user)
        {
            User = user;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItem.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            _orderItem.Remove(orderItem);
        }
    }
}
