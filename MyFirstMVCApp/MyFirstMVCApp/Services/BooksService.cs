using MyFirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCApp.Services
{
    public class BooksService : IBooksService
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { BookId = 1, Isbn = "38748734", Title = "Professional C# 7", Publisher = "Wrox Press"},
            new Book { BookId = 2, Isbn = "45745987", Title = "Professional C# 8", Publisher = "Wrox Press"},
        };

        public void AddBook(Book book) => throw new NotImplementedException();
        public IEnumerable<Book> GetBooks() => _books;
    }
}
