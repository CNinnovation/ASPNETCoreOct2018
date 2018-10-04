using System;

namespace EFCoreSample
{
    public class BooksService
    {
        private BooksContext _booksContext;
        public BooksService(BooksContext booksContext)
        {
            _booksContext = booksContext ?? throw new ArgumentNullException(nameof(booksContext));
        }

        public void AddBook()
        {
            bool created = _booksContext.Database.EnsureCreated();
            Console.WriteLine($"database created: {created}");

            _booksContext.Books.Add(new Book { Title = "Professional C# 7", Publisher = "Wrox Press" });

            int changed = _booksContext.SaveChanges();
            Console.WriteLine($"{changed} records changed");
        }
    }
}
