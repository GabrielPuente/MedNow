using Flunt.Notifications;
using Flunt.Validations;
using MedNow.Domain.DefaultEntity;

namespace MedNow.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        
        public decimal Price { get; private set; }

        public decimal? PromotionalPrice { get;  private set; }

        public string ImagePath { get;  private set; }

        public string Description { get; private set; }

        protected Product()
        {

        }

        public Product(string name, decimal price, decimal? promotionalPrice,string imagePath, string description)
        {
            Name = name;
            Price = price;
            PromotionalPrice = promotionalPrice;
            ImagePath = imagePath;
            Description = description;

            CheckDomainIsValid();
        }

        private void CheckDomainIsValid()
        {
            AddNotifications(new Contract<Notification>()
                  .IsNotNullOrEmpty(Name, "Name", "Campo nome é obrigatorio")
                  .IsNotNullOrEmpty(Description, "Description", "Descrição é invalido")
                  .IsGreaterThan(Price, 0, "Price", "Valor precisa ser maior que 0")
                  .IsNotNullOrEmpty(ImagePath, "ImagePath", "Caminho da imagem é obrigatorio"));
        }
    }
}
