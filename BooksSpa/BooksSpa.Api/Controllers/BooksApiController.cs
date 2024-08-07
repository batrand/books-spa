using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksSpa.Api.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok();
        }
    }
}
