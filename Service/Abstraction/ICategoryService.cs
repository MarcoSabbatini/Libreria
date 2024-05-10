using Libreria.Service.Actions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Abstraction
{
    public interface ICategoryService
    {
        public CategoryModificationResponse CategoryModification(CategoryDto dto, CategoryAction action);
    }
}
