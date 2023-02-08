using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    public interface IEventPublisher
    {
        void Publish(IDomainEvent @event);
        void Publish(IEnumerable<IDomainEvent> @events);
        void Publish(params IDomainEvent[] @events);
    }
}
