using MedNow.Application.Commands;
using MedNow.Application.Commands.Product;
using MedNow.Domain.Entities;

namespace MedNow.Application.Contracts.Services
{
    public interface IProductService
    {
        Task<CommandResponse<Product>> CreateProduct(CreateProductCommand command);

        Task<CommandResponse<Product>> UpdateProduct(Guid id, UpdateProductCommand command);

        Task<CommandResponse> DeleteProduct(Guid id);
    }
}
