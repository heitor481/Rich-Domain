using System;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}