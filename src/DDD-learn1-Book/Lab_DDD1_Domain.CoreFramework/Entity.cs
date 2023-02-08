using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    public abstract class Entity<TEntityId> : IEntity<TEntityId>
    {
        protected Entity(TEntityId id)
        {
            Id = id;
        }

        public TEntityId Id { get; private set; }
    }
}
