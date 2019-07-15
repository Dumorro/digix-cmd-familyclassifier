using Digix.Raking.Domain.Core.DomainEvents;

namespace Digix.Raking.EventDispatcher
{
    public abstract class BaseDomainEventHandler
    {
        public abstract void Handle(DomainEvent domainEvent);
    }
}
