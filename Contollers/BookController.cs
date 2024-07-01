using Libreria.Models.Entities.Actions;
using Libreria.Service.Abstraction;
using Libreria.Service.Factories;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Requests;
using Libreria.Service.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [Route("get/{id:int}")]
        public IActionResult GetBooks(BookReq req)
        {
            if(req.ValidateFilters())
            {
                return Ok(ResponseFactory.WithSuccess(new BookSearchingResponse()
                {
                    Result = _bookService.GetAllByFilter(req.EntityCreation(), req.start, req.end, (int)req.pageSize, (int)req.pageCount)
                }));
            }
            if (_bookService.GetBooks(request).Success) return Ok();
            else return BadRequest();
        }

        [HttpPost]
        [Route("librarymodifications")]
        [SwaggerOperation(
            Summary = "Modifies library",
            Description = "Modifies library depending on which action is chosen",
            OperationId = "ModBooks"
        )]
        public IActionResult LibraryModification(BookDto dto, BookActions action)
        {
            if (_bookService.LibraryModification(dto, action).Success) return Ok();
            else return BadRequest();
        }
    }
}
