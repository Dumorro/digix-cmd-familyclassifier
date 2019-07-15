using System;

namespace Digix.Raking.Domain.Core.DomainEvents
{
    public abstract class DomainEvent
    {
        public DateTime DateTimeOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
