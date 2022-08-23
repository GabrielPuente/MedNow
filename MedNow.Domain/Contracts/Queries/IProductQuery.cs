using MedNow.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedNow.Domain.Contracts.Queries
{
    public interface IProductQuery
    {
        Task<List<ProductViewModel>> Get();

        Task<ProductViewModel> GetById(Guid id);
    }
}
