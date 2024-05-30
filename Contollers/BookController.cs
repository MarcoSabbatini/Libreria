using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Libreria.Service.Abstraction;
using Libreria.Service.Models.Requests;
using Libreria.Models.Entities.Actions;
using Libreria.Service.Models.Dtos;

namespace Libreria.Contollers
{
    [ApiController]
    [Route("api/v1/[controller]/book")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase
    {
        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetBooks(BookRequest request) {
            if (_bookService.GetBooks(request).Success) return Ok();
            else return BadRequest();
        }

        [HttpPost]
        [Route("librarymodifications")]
        public IActionResult LibraryModification(BookDto dto, BookActions action)
        {
            if (_bookService.LibraryModification(dto, action).Success) return Ok();
            else return BadRequest();
        }
    }
}
