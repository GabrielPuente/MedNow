using MediatR;

namespace MedNow.Application.Mediator
{
    public class StockProductUpdatedMediator : IRequest
    {
        public Guid ProductId { get; set; }
    }
}
