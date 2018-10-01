using Microsoft.Extensions.DependencyInjection;
using System;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();
            var controller = Container.GetService<HomeController>();
            string greet = controller.Greeting("Katharina");
            Console.WriteLine(greet);
        }

        static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IHelloService, HelloService>();
            services.AddTransient<HomeController>();

            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
