using Flunt.Notifications;
using Flunt.Validations;

namespace MedNow.Application.Commands.Product
{
    public class CreateProductCommand : Command
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionalPrice { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public ushort InStock { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                 .IsNotNullOrEmpty(Name, "Name", "Nome do produto é obrigatorio")
                 .IsGreaterThan(Price, 0, "Price", "Valor do produto é obrigatorio")
                 .IsNotNullOrEmpty(ImagePath, "ImagePath", "Imagem para o produto é obrigatorio")
                 .IsGreaterThan(InStock,0, "InStock", "Quantidade em estoque deve ser maior que zero")
                 .IsLowerThan(InStock, 65.000, "InStock", "Quantidade em estoque deve ser menor que 65.000")
                 .IsNotNullOrEmpty(Description, "Description", "Descricao do produto é obrigatorio"));
        }
    }
}
