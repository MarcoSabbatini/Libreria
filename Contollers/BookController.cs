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

        [HttpPost]
        [Route("filtered_search")]
        public IActionResult GetBook(BookSearchReq req)
        {
            if(req.ValidateFilters())
            {
                return Ok(ResponseFactory.WithSuccess(new BookSearchingResponse()
                {
                    Result = _bookService.GetAllByFilter(req.EntityCreation(), req.start, req.end, (int)req.pageSize, (int)req.pageCount),
                    Success = true
                }));
            } else
            {
                return BadRequest(ResponseFactory.WithErrors("Choose at least one filter"));
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            if(_bookService.Get(id) != null)
            {
                _bookService.Delete(id);
                return Ok(ResponseFactory.WithSuccess());  
            }
            return BadRequest(ResponseFactory.WithErrors("Select a valid id"));
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult EditBook(BookModificationReq req)
        {
            if(_bookService.Get((int)req.Id) != null) {
                return Ok(ResponseFactory.WithSuccess(_bookService.Modify(req.EntityCreation())));
            } else return BadRequest(ResponseFactory.WithErrors("Select a valid id"));
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(BookCreationReq req)
        {
            _bookService.Add(req.EntityCreation());
            return Ok(ResponseFactory.WithSuccess());
        }

        /*[HttpPost]
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
        }*/
    }
}
