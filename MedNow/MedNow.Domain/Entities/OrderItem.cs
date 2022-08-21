using MedNow.Domain.DefaultEntity;

namespace MedNow.Domain.Entities
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        protected OrderItem()
        {

        }

        public OrderItem(Guid orderId, Product product, int quantity)
        {
            OrderId = orderId;
            Product = product;
            Quantity = quantity;
        }
    }
}
