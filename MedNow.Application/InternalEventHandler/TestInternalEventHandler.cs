using MedNow.Application.InternalEvent;
using Rebus.Handlers;

namespace CBF.Application.InternalEventHandler
{
    public class TestInternalEventHandler : IHandleMessages<TestInternalEvent>
    {
      
        public async Task Handle(TestInternalEvent message)
        {
            throw new Exception(message.Nome);
        }
    }
}
