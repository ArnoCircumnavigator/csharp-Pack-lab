using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.Contexts
{
    public class StoreBookContext
    {
        private ILibraryService library = null;
        private Book book = null;
        public StoreBookContext(ILibraryService library, Book book)
        {
            this.library = library;
            this.book = book;
        }
        public void Interaction(int count, string location)
        {
            library.StoreBook(book, count, location);
        }
    }
}
