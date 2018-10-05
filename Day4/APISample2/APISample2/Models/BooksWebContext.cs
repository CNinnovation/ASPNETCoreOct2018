using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APISample2
{
    public partial class BooksWebContext : DbContext
    {
        public BooksWebContext()
        {
        }

        public BooksWebContext(DbContextOptions<BooksWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);
            });
        }
    }
}
