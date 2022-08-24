using MedNow.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedNow.Domain.Contracts.Queries
{
    public interface IOrderQuery
    {
        Task<List<ProductViewModel>> Get(Guid userId);

        Task<List<ProductViewModel>> GetById(Guid id);
    }
}
