using Libreria.Models.Entities.Actions;
using Libreria.Service.Abstraction;
using Libreria.Service.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Contollers
{
    [ApiController]
    [Route("api/v1/[controller]/category")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) { 
            this._categoryService = categoryService;
        }

        [HttpPost]
        [Route("categorymodification")]
        public IActionResult CategoryModification(CategoryDto dto, CategoryActions action)
        {
            if (_categoryService.CategoryModification(dto, action).Success) return Ok();
            else return BadRequest();
        }
    }
}
