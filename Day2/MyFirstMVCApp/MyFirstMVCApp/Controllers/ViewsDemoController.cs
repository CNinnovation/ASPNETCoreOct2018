using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Services;

namespace MyFirstMVCApp.Controllers
{
    public class ViewsDemoController : Controller
    {
        private readonly IBooksService _booksService;

        public ViewsDemoController(IBooksService booksService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        }

        public IActionResult Index()
        {
            ViewData["Data1"] = "data A from the controller";
            ViewBag.Data2 = "data B from the controller";
            return View("Index2");
        }

        public IActionResult Books()
        {
            return View(_booksService.GetBooks());
        }

        public IActionResult Books2()
        {
            return View("BooksWithLayout", _booksService.GetBooks());
        }

        public IActionResult MyPartialView()
        {
            return PartialView("MyPartialView");
        }

        public IActionResult UseJquery()
        {
            return View();
        }
    }
}