using Flunt.Notifications;
using Flunt.Validations;
using MedNow.Domain.DefaultEntity;

namespace MedNow.Domain.Entities
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal TotalValue { get; set; }

        protected OrderItem()
        {

        }

        public OrderItem(Guid orderId, Product product, int quantity)
        {
            OrderId = orderId;
            Product = product;
            Quantity = quantity;

            CalculateTotalValue();
            CheckDomainIsValid();
        }

        private void CheckDomainIsValid()
        {
            AddNotifications(new Contract<Notification>()
                  .IsNotEmpty(OrderId, "Name", "Campo nome é obrigatorio")
                  .IsNotEmpty(Product.Id, "Product.Id", "Obrigatorio informar um produto")
                  .IsGreaterOrEqualsThan(Quantity, 1, "Quantity", "Quantidade precisa ser maior ou igual a 1"));
        }

        private void CalculateTotalValue()
        {
            TotalValue = Product.PromotionalPrice.HasValue ? Product.PromotionalPrice.Value * Quantity : Product.Price * Quantity;
        }
    }
}
