using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return _bookService.GetBooks();
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return book;
        }

        // POST: api/books
        [HttpPost]
        public ActionResult AddBook([FromBody] Book newBook)
        {
            _bookService.AddBook(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var result = _bookService.UpdateBook(id, updatedBook);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var result = _bookService.DeleteBook(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
