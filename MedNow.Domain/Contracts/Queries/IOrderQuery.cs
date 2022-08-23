using MedNow.Domain.ViewModels;

namespace MedNow.Domain.Contracts.Queries
{
    public interface IOrderQuery
    {
        Task<List<ProductViewModel>> Get(Guid userId);

        Task<ProductViewModel> GetById(Guid id);
    }
}
