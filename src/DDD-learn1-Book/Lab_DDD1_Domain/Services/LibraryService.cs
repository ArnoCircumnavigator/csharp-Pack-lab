using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Ioc;
using Lab_DDD1_Domain.Repositories;
using Lab_DDD1_Domain.Roles;

namespace Lab_DDD1_Domain.Services
{
    public class LibraryService : ILibraryService
    {
        private IBorrowInfoRepository borrowInfoRepository = DependencyResolver.Resolve<IBorrowInfoRepository>();
        private IBookStoreInfoRepository bookStoreInfoRepository = DependencyResolver.Resolve<IBookStoreInfoRepository>();

        public bool GetBookStoreInfo(UniqueId bookid, out BookStoreInfo? bookStoreInfo)
        {
            return bookStoreInfoRepository.GetBookStoreInfo(bookid, out bookStoreInfo);
        }

        public void LendBook(Book book, IBorrower borrower)
        {
            bookStoreInfoRepository.GetBookStoreInfo(book.Id, out var bookStoreInfo);
            if (bookStoreInfo.Count.Equals(0))
            {
                throw new Exception($"The count of book {book.BookName} in library is zero, so you cannot borrow it.");
            }
            bookStoreInfo.DecreaseCount();
            bookStoreInfo.Location = string.Empty;

            borrowInfoRepository.Add(new BorrowInfo(book, borrower, DateTime.Now));
        }

        public void ReceiveReturnedBook(Book book, IBorrower borrower)
        {
            borrowInfoRepository.FindNotReturnedBorrowInfo(borrower.Id, book.Id, out var borrowInfo);
            if (borrowInfo == null)
                throw new Exception("The borrowInfo can't find in repository");
            borrowInfo.ReturnTime = DateTime.Now;

            //这里，真正的系统还会计算归还时间是否超期，计算罚款之类的逻辑，因为我这个是一个演示的例子，所以不做这个处理了

            //这里只更新书本的数量信息，因为还书时并不是马上把书本放回书架的，所以此时书本的书架位置信息还是保留为空
            //等到我们将这本书放到书架的某个位置时，才会更新其位置信息
            bookStoreInfoRepository.GetBookStoreInfo(book.Id, out var bookStoreInfo);
            bookStoreInfo.IncreaseCount();
        }

        public void StoreBook(Book book, int count, string location)
        {
            var bookStoreInfo = new BookStoreInfo(book, count)
            {
                Location = location
            };
            bookStoreInfoRepository.Add(bookStoreInfo);
        }
    }
}
