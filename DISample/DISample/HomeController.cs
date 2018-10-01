using System;
using System.Collections.Generic;
using System.Text;

namespace DISample
{
    public class HomeController
    {
        private readonly IHelloService _helloService;

        public HomeController(IHelloService helloService)
        {
            _helloService = helloService ?? throw new ArgumentNullException(nameof(helloService));
        }

        public string Greeting(string name) => _helloService.Hello(name);
    }
}
