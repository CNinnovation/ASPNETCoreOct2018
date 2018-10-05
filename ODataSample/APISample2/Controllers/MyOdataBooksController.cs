using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISample2.Controllers
{

    public class MyOdataBooksController : ODataController
    {
        private readonly BooksWebContext _booksContext;

        public MyOdataBooksController(BooksWebContext booksContext)
        {
            _booksContext = booksContext;
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Book> Get(ODataQueryOptions options)
        {
            var settings = new ODataValidationSettings
            {
                MaxExpansionDepth = 4
            };
            options.Validate(settings);
            var books = _booksContext.Books;
            return books;
        }

        [EnableQuery()]
        public SingleResult<Book> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_booksContext.Books.Where(b => b.BookId == key));
        }


    }
}