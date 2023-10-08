using MedNow.Application.Commands;
using MedNow.Application.Contracts.Services;
using MedNow.Domain.Entities;
using MedNow.Infra.Contracts;
using MedNow.Application.Commands.Product;
using Flunt.Notifications;

namespace MedNow.Application.Services
{
    public class ProductService : CommandHandler, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<CommandResponse<Product>> CreateProduct(CreateProductCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResponse<Product>(null, command.Notifications);
            }

            var product = new Product(command.Name, command.Price, command.PromotionalPrice, command.ImagePath, command.Description, command.InStock);

            if (!product.IsValid)
            {
                command.AddNotification(string.Empty, "Erro ao criar produto");
                return Fail<Product>("Erro ao criar produto.", product.Notifications);
            }

            await _repository.Add(product);
            await _repository.Commit();

            return Ok(product);
        }

        public async Task<CommandResponse<Product>> UpdateProduct(Guid id, UpdateProductCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResponse<Product>(null, command.Notifications);
            }

            var product = await _repository.GetById(id);

            if (product == null)
            {
                command.AddNotification("Id", "Produto não encontrado");
                return Fail<Product>("Produto não encontrado.", command.Notifications);
            }

            product.Update(command.Name, command.Price, command.PromotionalPrice, command.ImagePath, command.Description, command.InStock);

            if (!product.IsValid)
                return Fail<Product>("Erro ao atualizar o produto.", product.Notifications);

            _repository.Update(product);
            await _repository.Commit();

            return Ok(product, product.Notifications);
        }

        public async Task<CommandResponse> DeleteProduct(Guid id)
        {
            var product = await _repository.GetById(id);

            if (product == null)
            {
                var notifications = new List<Notification>
                {
                    new Notification() { Key = "Produto", Message = "Produto nao localizado" }
                };
                return Fail<Product>("Erro ao atualizar o produto.", notifications.AsReadOnly());
            }

            _repository.Delete(product);
            await _repository.Commit();

            return Ok(product, product.Notifications);
        }
    }
}
