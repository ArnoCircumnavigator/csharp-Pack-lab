using Lab_DDD1_Domain.CoreFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.Entities
{
    /// <summary>
    /// 图书入库信息
    /// </summary>
    public class BookStoreInfo : AggregateRoot<UniqueId>
    {
        public BookStoreInfo(Book book, int count)
            : this(new UniqueId(), book, count)
        {

        }

        public BookStoreInfo(UniqueId id, Book book, int count)
            : base(id)
        {
            this.Book = book;
            this.Count = count;
        }

        public Book Book { get; private set; }
        public int Count { get; private set; }
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// 入一本
        /// </summary>
        public void IncreaseCount()
        {
            this.Count++;
        }
        public void DecreaseCount()
        {
            this.Count--;
        }
    }
}
