using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.Contexts
{
    public class BorrowBooksContext
    {
        private LibraryAccount account = null;
        private IEnumerable<Book> books = null;
        public BorrowBooksContext(LibraryAccount account, IEnumerable<Book> books)
        {
            this.account = account;
            this.books = books;
        }
        public void Interaction()
        {
            var borrower = account.ActAs<IBorrower>();
            foreach (var book in books)
            {
                borrower?.BorrowBook(book);
            }
        }
    }
}
