using System;

namespace UnipPim.Hotel.Dominio.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime InsertDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
