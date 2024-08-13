using BooksSpa.Api.Constants;
using BooksSpa.Api.Models;
using BooksSpa.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksSpa.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class BooksApiController : ControllerBase
    {
        private readonly IBookRepositoryService _books;
        private readonly ILogger<BooksApiController> _logger;

        public BooksApiController(IBookRepositoryService books, ILogger<BooksApiController> logger)
        {
            _books = books;
            _logger = logger;
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        [HttpPost]
        [Route("book")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(typeof(BookWithId), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookWithId>> CreateBook([FromBody] Book book)
        {
            try
            {
                var createdBook = await _books.CreateBookAsync(book);
                return Created($"book/{createdBook.Id}", createdBook);
            }
            catch (Exception ex)
            {
                return LogErrorAndRespond(ex, 
                    "There was an error creating the book",
                    "Exception when creating new book");
            }
        }

        /// <summary>
        /// Get specific book
        /// </summary>
        /// <param name="id">ID of book to retrieve</param>
        [HttpGet]
        [Route("book/{id}")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(typeof(BookWithId), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookWithId>> GetSpecificBook(int id)
        {
            try
            {
                var existingBook = await _books.GetBookAsync(id);
                if (existingBook == null) return NotFound();
                return Ok(existingBook);
            }
            catch (Exception ex)
            {
                return LogErrorAndRespond(ex, 
                    "There was an error finding your book",
                    "Exception when finding book with ID {Id}", id);
            }
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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookWithId>> UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                var bookWithId = new BookWithId(book) { Id = id };
                var updatedBook = await _books.UpdateBookAsync(bookWithId);
                if (updatedBook == null) return NotFound();
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                return LogErrorAndRespond(ex, 
                    "There was an error updating your book",
                    "Exception when updating book with ID {Id}", id);
            }
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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookWithId>> DeleteBook(int id)
        {
            try
            {
                var deleted = await _books.DeleteBookAsync(id);
                return deleted
                    ? Ok()
                    : NotFound();
            }
            catch (Exception ex)
            {
                return LogErrorAndRespond(ex, 
                    "There was an error deleting your book",
                    "Exception when deleting book with ID {Id}", id);
            }
        }
        
        /// <summary>
        /// Get all books
        /// </summary>
        [HttpGet]
        [Route("books")]
        [Produces(ContentTypes.Json)]
        [ProducesResponseType(typeof(IEnumerable<BookWithId>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<BookWithId>>> GetAllBooks()
        {
            try
            {
                var allBooks = await _books.GetAllBooksAsync();
                return Ok(allBooks);
            }
            catch (Exception ex)
            {
                return LogErrorAndRespond(ex, 
                    "There was an error loading all books",
                    "Exception when loading all books");
            }
        }
        
        private ActionResult LogErrorAndRespond(Exception ex, string userMessage, string logMessage, params object?[] logArgs)
        {
            _logger.LogError(ex, logMessage, logArgs);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new ErrorResponse(userMessage));
        }
    }
}
