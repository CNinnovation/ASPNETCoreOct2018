using System;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new HomeController();
            string greet = controller.Greeting("Stephanie");
            Console.WriteLine(greet);
        }
    }
}
