namespace Digix.Raking.Domain.Core.DomainEvents
{
    public interface IDomainEventHandler<T> where T : DomainEvent
    {
        void Handle(T domainEvent);
    }
}
