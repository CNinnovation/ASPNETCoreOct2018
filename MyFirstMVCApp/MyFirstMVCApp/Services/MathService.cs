using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCApp.Services
{
    public class MathService : IMathService
    {
        public int Add(int x, int y) => x + y;
        public int Subtract(int x, int y) => x - y;

        public int Multiply(int x, int y) => x * y;

        public int Divide(int x, int y) => x / y;

    }
}
