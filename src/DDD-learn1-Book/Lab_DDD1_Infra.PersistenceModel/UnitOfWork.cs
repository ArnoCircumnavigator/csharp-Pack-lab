using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lab_DDD1_Infra.PersistenceModel
{
    public class UnitOfWork : IUnitOfWork
    {
        public List<IPersistableRepository> PersistableRepositories { get; private set; }

        public UnitOfWork()
        {
            PersistableRepositories = new List<IPersistableRepository>();
        }

        public void RegisterRepository(IPersistableRepository repository)
        {
            if (!PersistableRepositories.Contains(repository))
            {
                PersistableRepositories.Add(repository);
            }
        }

        /// <summary>
        /// todo
        /// 这里的设计，我觉得是存在违反<<里氏替换原则>>的可能的
        /// 由于超类中存在实现，那么不满足“在任何时候，子类都能代替超类”
        /// </summary>
        public virtual void SubmitChanges()
        {
            using TransactionScope transaction = new();
            foreach (IPersistableRepository repository in PersistableRepositories)
            {
                repository.PersistChanges();
            }
            transaction.Complete();
        }

        public virtual void Dispose()
        {

        }
    }
}
