using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Ioc;
using Lab_DDD1_Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.Roles
{
    public class Borrower : Role<LibraryAccount, UniqueId>, IBorrower
    {
        private readonly ILibraryService library = DependencyResolver.Resolve<ILibraryService>();

        public Borrower(LibraryAccount account)
            : base(account)
        {
            if (account.IsLocked)
            {
                throw new NotSupportedException("Locked account is not allowed to act as borrower.");
            }
        }

        public void BorrowBook(Book book)
        {
            library.LendBook(book, this);
        }
        public void ReturnBook(Book book)
        {
            library.ReceiveReturnedBook(book, this);
        }
    }
}
