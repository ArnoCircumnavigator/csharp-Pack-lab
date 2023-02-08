using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.PersistenceModel
{
    /// <summary>
    /// 处理事务
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void RegisterRepository(IPersistableRepository repository);
        void SubmitChanges();
    }
}
