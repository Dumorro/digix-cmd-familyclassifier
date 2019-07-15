using Autofac;
using Digix.Raking.Domain.Core.DomainEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digix.Raking.EventDispatcher
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {

        private readonly IComponentContext _container;
        public DomainEventDispatcher(IComponentContext container)
        {
            _container = container;
        }

        public async Task Dispatch(DomainEvent domainEvent)
        {
            Type handlerType = typeof(IHandle<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());

            IEnumerable handlers = (IEnumerable)_container.Resolve(typeof(IEnumerable<>).MakeGenericType(handlerType));

            IList<DomainEventHandler> wrappedHandlers = new List<DomainEventHandler>();

            foreach(var handler in handlers)
            {
                wrappedHandlers.Add((DomainEventHandler)Activator.CreateInstance(wrapperType, handler));
            }

            foreach (DomainEventHandler handler in wrappedHandlers)
            {
                await handler.Handle(domainEvent);
            }
        }
    }
}
