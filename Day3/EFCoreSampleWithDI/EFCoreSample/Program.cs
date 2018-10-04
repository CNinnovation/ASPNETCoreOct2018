using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreSample
{
    class Program
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=Books3;trusted_connection=true";

        static void Main(string[] args)
        {
            RegisterServices();
            UseBooksService();
        }

        private static void UseBooksService()
        {
            var service = Container.GetService<BooksService>();
            service.AddBook();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<BooksService>();
            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            Container = services.BuildServiceProvider();
        }
        public static IServiceProvider Container { get; private set; }
    }
}
