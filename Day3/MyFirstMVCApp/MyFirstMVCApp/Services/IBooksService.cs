using System.Collections.Generic;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();

        void AddBook(Book book);
    }
}