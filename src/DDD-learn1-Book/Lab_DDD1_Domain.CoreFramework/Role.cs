using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    public abstract class Role<TActor, TRoleId> :
        Entity<TRoleId>,
        IAggregateRoot<TRoleId>,
        IRole<TRoleId>
        where TActor :
        Entity<TRoleId>,
        IAggregateRoot<TRoleId>
    {
        public Role(TActor actor)
            : base(actor.Id)
        {
            this.Actor = actor;
        }
        protected TActor Actor { get; private set; }
    }
}
