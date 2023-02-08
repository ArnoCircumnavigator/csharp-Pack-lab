using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.Repositories
{
    public interface ILibraryAccountRepository : IRepository<LibraryAccount, UniqueId>
    {

    }
}
