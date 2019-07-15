using Digix.Raking.Domain.Core.DomainEvents;
using System.Threading.Tasks;

namespace Digix.Raking.EventDispatcher
{
    public abstract class DomainEventHandler
    {
        public abstract Task Handle(DomainEvent domainEvent);
    }
    public class DomainEventHandler<T> : DomainEventHandler where T : DomainEvent
    {
        private readonly IHandle<T> _handler;
        public DomainEventHandler()
        { }

        public DomainEventHandler(IHandle<T> handler)
        {
            _handler = handler;
        }

        public override async Task Handle(DomainEvent domainEvent)
        {
            await _handler.Handle((T)domainEvent);
        }
    }
}
