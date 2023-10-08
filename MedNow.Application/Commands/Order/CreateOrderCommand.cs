using Flunt.Notifications;
using Flunt.Validations;

namespace MedNow.Application.Commands.Order
{
    public class CreateOrderCommand : Command
    {
        public Guid UserId { get; set; }

        public List<ProductCommand> Products { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                 .IsGreaterThan(Products.Count, 0, "Products", "Precisa selecionar pelo menos um produto"));
        }
    }

    public class ProductCommand
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }
    }
}
