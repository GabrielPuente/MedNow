using MedNow.Domain.ViewModels;

namespace MedNow.Application.Contracts.Queries
{
    public interface IOrderQuery
    {
        Task<List<ProductViewModel>> Get(Guid userId);

        Task<List<ProductViewModel>> GetById(Guid id);
    }
}
