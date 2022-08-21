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
        }
    }
}
