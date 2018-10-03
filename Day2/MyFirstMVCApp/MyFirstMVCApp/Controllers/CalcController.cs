using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCApp.Controllers
{
    public class CalcController : Controller
    {
        private readonly IMathService _mathService;

        public CalcController(IMathService mathService)
        {
            _mathService = mathService ?? throw new ArgumentNullException(nameof(mathService));
        }
        public int Add(int x, int y) => _mathService.Add(x, y);
        public int Subtract(int x, int y) => x - y;
        public int Multiply(int x, int y) => x * y;
        public int Divide(int x, int y) => x / y;
    }
}
