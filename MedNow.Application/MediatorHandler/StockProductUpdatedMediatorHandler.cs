using MediatR;
using MedNow.Application.Mediator;

namespace MedNow.Application.MediatorHandler
{
    public class StockProductUpdatedMediatorHandler : IRequestHandler<StockProductUpdatedMediator>
    {
        public Task Handle(StockProductUpdatedMediator request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
