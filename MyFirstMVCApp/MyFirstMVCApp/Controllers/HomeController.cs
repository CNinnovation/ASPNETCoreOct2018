using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index() => "Index";

        public string About() => "About";

        public string WithId(string id) => $"<h1>with id: {id}</h1>";
    }
}
