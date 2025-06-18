using Sample.API.Models;
using Sample.API.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Sample.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;
        public BooksController()
        {
            _bookService = new BookService();

        }

        //[HttpGet, Route("")]
        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        //[HttpGet, Route("{id:int}")]
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetBookId(int id)
        {
            var books = _bookService.GetBookById(id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public IHttpActionResult CreateBook(Book book)
        {
            _bookService.Create(book);
            return Created($"mfsi/books/{book.BookId}", book);
        }

        [HttpGet]
        [Route("search")]
        public IHttpActionResult Search(string title)
        {
            var results = _bookService.SearchByTitle(title);
            return Ok(results);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _bookService.GetBookById(id);
            if (existing == null)
                return NotFound();

            _bookService.Update(id, book);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            _bookService.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
