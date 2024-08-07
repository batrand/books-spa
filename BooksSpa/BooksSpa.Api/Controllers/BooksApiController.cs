using BooksSpa.Api.Constants;
using BooksSpa.Api.Models;
using BooksSpa.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksSpa.Api.Controllers
{
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly IBookRepositoryService _books;

        public BooksApiController(IBookRepositoryService books)
        {
            _books = books;
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        [HttpPost]
        [Route("book")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(typeof(BookWithId), StatusCodes.Status201Created)]
        public async Task<ActionResult<BookWithId>> CreateBook([FromBody] Book book)
        {
            var createdBook = await _books.CreateBookAsync(book);
            return Created($"book/{createdBook.Id}", createdBook);
        }

        /// <summary>
        /// Get specific book
        /// </summary>
        /// <param name="id">ID of book to retrieve</param>
        [HttpGet]
        [Route("book/{id}")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(typeof(BookWithId), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookWithId> GetSpecificBook(int id)
        {
            return Ok();
        }
        
        /// <summary>
        /// Update specific book
        /// </summary>
        /// <param name="id">ID of book to update</param>
        /// <param name="book">Details to be updated</param>
        [HttpPut]
        [Route("book/{id}")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(typeof(BookWithId), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookWithId> UpdateBook(int id, [FromBody] Book book)
        {
            return Ok();
        }
        
        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id">ID of book to delete</param>
        [HttpDelete]
        [Route("book/{id}")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookWithId> DeleteBook(int id)
        {
            return Ok();
        }
        
        /// <summary>
        /// Get all books
        /// </summary>
        [HttpGet]
        [Route("books")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(typeof(IEnumerable<BookWithId>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookWithId>>> GetAllBooks()
        {
            var allBooks = await _books.GetAllBooksAsync();
            return Ok(allBooks);
        }
    }
}
