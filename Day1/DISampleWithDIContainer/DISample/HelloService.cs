using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class HelloService : IHelloService
    {
        public string Hello(string name) => $"Hello, {name}";
    }
}
