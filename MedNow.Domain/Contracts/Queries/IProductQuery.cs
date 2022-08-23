using MedNow.Domain.ViewModels;

namespace MedNow.Domain.Contracts.Queries
{
    public interface IProductQuery
    {
        Task<List<ProductViewModel>> Get();

        Task<ProductViewModel> GetById(Guid id);
    }
}
