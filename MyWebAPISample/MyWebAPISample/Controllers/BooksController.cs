using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPISample.Models;
using MyWebAPISample.Services;

namespace MyWebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_booksService.GetAllBooks());
        }

        // GET api/values
        [HttpGet("{id}", Name ="GetBookById")]
        public ActionResult<Book> GetBook(int id)
        {
            return Ok(_booksService.GetBookById(id));
        }

        [HttpPost]
        public ActionResult<Book> PostBook([FromBody] Book book)
        {
            _booksService.AddBook(book);
            return CreatedAtRoute("GetBookById", new { id = book.BookId }, book);
        }

    }
}