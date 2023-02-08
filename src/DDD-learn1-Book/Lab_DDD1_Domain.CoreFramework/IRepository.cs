﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    public interface IRepository<TAggregateRoot, TAggregateRootId>
        where TAggregateRoot : Entity<TAggregateRootId>, IAggregateRoot<TAggregateRootId>
    {
        IEnumerable<TAggregateRoot> GetAll();
        TAggregateRoot Get(TAggregateRootId id);
        void Add(TAggregateRoot aggregateRoot);
    }
}
