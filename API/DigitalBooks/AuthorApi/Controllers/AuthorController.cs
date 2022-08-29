
using AuthorApi.Authorization;
using AuthorApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelService.Model;
using System.Security.Claims;

namespace AuthorApi.Controllers
{
    [Route("api/Author")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        AppAuthorization appAuthorization = new AppAuthorization();

        public AuthorController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        
        [HttpPost("AddBook")]
        public IActionResult AddBook(Books books)
        {
            try
            {

                var identity = HttpContext.User.Identity as ClaimsIdentity;

                if (appAuthorization.AppAuth(identity))
                {
                    var result = _bookService.AddBook(books);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Books books)
        {
            try
            {

                var identity = HttpContext.User.Identity as ClaimsIdentity;

                if (appAuthorization.AppAuth(identity))
                {
                    var result = _bookService.UpdateBook(books);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor(Author author)
        {
            try
            {
                var result = _authorService.AddAuthor(author);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
