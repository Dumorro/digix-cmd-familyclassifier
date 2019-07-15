using System.Threading.Tasks;

namespace Digix.Raking.Domain.Core.DomainEvents
{
    public interface IHandle<T> where T : DomainEvent
    {
        Task Handle(T domainEvent);
    }
}
