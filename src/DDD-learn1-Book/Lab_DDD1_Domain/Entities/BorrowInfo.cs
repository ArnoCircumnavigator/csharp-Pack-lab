using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.Entities
{
    public class BorrowInfo : AggregateRoot<UniqueId>
    {
        public BorrowInfo(Book book, IBorrower borrower, DateTime borrowTime)
            : this(new UniqueId(), book, borrower, borrowTime)
        {

        }
        public BorrowInfo(UniqueId id, Book book, IBorrower borrower, DateTime borrowTime)
            : base(id)
        {
            this.Book = book;
            this.Borrower = borrower;
            this.BorrowTime = borrowTime;
        }

        public Book Book { get; private set; }
        public IBorrower Borrower { get; private set; }
        public DateTime BorrowTime { get; private set; }
        public DateTime? ReturnTime { get; set; }
    }
}
