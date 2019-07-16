using System;

namespace Digix.Raking.Domain.Core.Entities.Base
{
    public abstract class Entity : Entity<Guid>
    {
    }
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
