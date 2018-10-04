using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Microsoft.Extensions.Http;
using System.Threading.Tasks;
using WebAPIClient.Models;
using Polly;
using Microsoft.Extensions.Logging;

namespace WebAPIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("client - wait for service started");
            Console.ReadLine();
            RegisterServices();
            await GetBooksAsync();
            await AddBookAsync();
            await GetBooksAsync();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddFilter((category, level) => true);
                builder.AddConsole(options => options.IncludeScopes = true);
            });
            services.AddHttpClient("books", config =>
            {
                config.BaseAddress = new Uri("http://localhost1:50804");
            })
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10) }))  // network failures, HTTP 5xx, HTTP 408
            .AddTypedClient<BooksClientService>();
            // services.AddTransient<BooksClientService>();

            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }

        private static async Task GetBooksAsync()
        {
            //// bad!!!
            //using (var client = new HttpClient())
            //{

            //}
            Console.WriteLine(nameof(GetBooksAsync));

            var service = Container.GetService<BooksClientService>();
            var books = await service.GetBooksAsync();
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();
        }

        private static async Task AddBookAsync()
        {
            Console.WriteLine("adding book");
            var service = Container.GetService<BooksClientService>();
            await service.AddBookAsync(new Book { Title = "a new book", Publisher = "some publisher" });
        }
    }
}
