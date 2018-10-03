using MyFirstASPNETCoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstASPNETCoreApp.MyControllers
{
    public class MyHomeController
    {
        private readonly IHelloService _helloService;

        public MyHomeController(IHelloService helloService)
        {
            _helloService = helloService ?? throw new ArgumentNullException(nameof(helloService));
        }

        public string Index(string name) => _helloService.Hello(name);
    }
}
