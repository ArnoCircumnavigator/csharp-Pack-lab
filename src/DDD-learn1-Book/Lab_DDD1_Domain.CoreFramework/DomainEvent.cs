using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            Results = new List<object>();
        }
        public IList<object> Results { get; private set; }

        public T GetTypedResult<T>()
        {
            var filteredResults = GetTypedResults<T>();
            if (filteredResults.Count > 0)
            {
                return filteredResults[0];
            }
            return default!;
        }

        public IList<T> GetTypedResults<T>()
        {
            return Results.OfType<T>().ToList();
        }
    }
}
