using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Repositories;
using Lab_DDD1_Infra.PersistenceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Infra.Persistence
{
    public class BookStoreInfoRepository : Repository<BookStoreInfo, UniqueId>, IBookStoreInfoRepository
    {
        public bool GetBookStoreInfo(UniqueId bookId, out BookStoreInfo info)
        {
            info = GetAll().FirstOrDefault(bookStoreInfo => bookStoreInfo.Book.Id == bookId);
            return info != null;
        }
    }
}
