using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Services
{
    public class BooksDBService : IBooksService
    {
        private readonly BooksContext _booksContext;
        public BooksDBService(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public void AddBook(Book book)
        {
            _booksContext.Books.Add(book);
            _booksContext.SaveChanges();
        }
        public IEnumerable<Book> GetBooks() => _booksContext.Books.ToList();
    }
}
