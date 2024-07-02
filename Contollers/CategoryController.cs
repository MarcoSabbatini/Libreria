using Libreria.Models.Entities.Actions;
using Libreria.Service.Abstraction;
using Libreria.Service.Factories;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Contollers
{
    //with this all controllers in the assembly are treated as http operations
    [ApiController]
    [Route("api/v1/[controller]/category")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpPut]
        [Route("add")]
        public IActionResult CategoryCreation(CatCreationReq req)
        {
            var category = req.EntityCreation();
            var resp = _categoryService.Get(category.Name);
            if (resp == null)
            {
                _categoryService.Add(category);
                return Ok(ResponseFactory.WithSuccess());
            } else return BadRequest(ResponseFactory.WithErrors("No category corresponding to this id"));
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult CategoryDelete(int id) 
        {
            var resp = _categoryService.Get(id);
            if (resp == null)
            {
                return BadRequest(ResponseFactory.WithErrors("No category corresponding to this id"));
            }
            if (resp.Books.Count == 0) 
            {
                _categoryService.Delete(id);
                return Ok(ResponseFactory.WithSuccess());
            } else
            {
                return BadRequest(ResponseFactory.WithErrors("There are books associated to this category"));
            }
        }


    }
}
