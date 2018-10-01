using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;

namespace LoggingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();

            var s = Container.GetService<MyService>();
            s.Foo("test");
            s.Bar();
            Console.WriteLine("Main end");
            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<MyService>();
            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
                config.AddFilter(level => true);
            });
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
