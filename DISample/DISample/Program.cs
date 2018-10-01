using System;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new HomeController(new HelloService());
            string greet = controller.Greeting("Matthias");
            Console.WriteLine(greet);
        }
    }
}
