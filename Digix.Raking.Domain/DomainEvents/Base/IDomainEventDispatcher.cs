using System.Threading.Tasks;

namespace Digix.Raking.Domain.Core.DomainEvents
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(DomainEvent domainEvent);
    }
}
