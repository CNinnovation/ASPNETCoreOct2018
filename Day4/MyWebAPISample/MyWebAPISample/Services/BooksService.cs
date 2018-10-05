using MyWebAPISample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPISample.Services
{
    public class BooksService : IBooksService
    {
        private List<Book> _books;

        public BooksService()
        {
            _books = new List<Book>()
            {
                new Book { BookId = 1, Title = "one", Publisher = "a pub"},
                new Book { BookId = 2, Title = "two", Publisher = "a pub"},
            };
        }

        public IEnumerable<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.SingleOrDefault(b => b.BookId == id);

        public void AddBook(Book book)
        {
            book.BookId = _books.Max(b => b.BookId) + 1;
            _books.Add(book);
        }
    }
}
