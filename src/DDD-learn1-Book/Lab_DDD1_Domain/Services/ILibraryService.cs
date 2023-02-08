using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Roles;

namespace Lab_DDD1_Domain.Services
{
    public interface ILibraryService
    {
        /// <summary>
        /// 把书借给某个人
        /// </summary>
        /// <param name=""></param>
        /// <param name="borrower"></param>
        void LendBook(Book book, IBorrower borrower);
        /// <summary>
        /// 接受一本还回来的书
        /// </summary>
        /// <param name="book"></param>
        /// <param name="borrower"></param>
        void ReceiveReturnedBook(Book book, IBorrower borrower);
        /// <summary>
        /// 图书入库
        /// </summary>
        /// <param name="book"></param>
        /// <param name="count"></param>
        /// <param name="location"></param>
        void StoreBook(Book book, int count, string location);
        /// <summary>
        /// 提供某本书的库存信息
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="bookStoreInfo"></param>
        /// <returns></returns>
        bool GetBookStoreInfo(UniqueId bookid,out BookStoreInfo? bookStoreInfo);
    }
}
