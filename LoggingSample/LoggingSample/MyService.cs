using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingSample
{
    public class MyService
    {
        private readonly ILogger<MyService> _logger;
        public MyService(ILogger<MyService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Foo(string n)
        {
            // _logger.Log(LogLevel.Information, "Foo started", n);
            _logger.LogInformation("Foo started", n);
          
        }

        public void Bar()
        {
            _logger.LogError("Some error in Bar");
        }
    }
}
