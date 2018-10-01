using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class HomeController
    {
        public string Greeting(string name)
        {
            var service = new HelloService();
            return service.Hello(name);
        }
    }
}
