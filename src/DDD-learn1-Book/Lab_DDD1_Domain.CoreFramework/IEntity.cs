using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    public interface IEntity<TEntityId>
    {
        TEntityId Id { get; }
    }
}
