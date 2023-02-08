using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;

namespace Lab_DDD1_Domain.Repositories
{
    public interface IBookStoreInfoRepository : IRepository<BookStoreInfo, UniqueId>
    {
        bool GetBookStoreInfo(UniqueId bookId, out BookStoreInfo bookStoreInfo);
    }
}
