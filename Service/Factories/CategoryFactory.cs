using Libreria.Service.Models.Dtos;
using Libreria.Models.Entities;

namespace Libreria.Service.Factories
{
    public class CategoryFactory
    {
        public Category CreateEntity(CategoryDto dto)
        {
            return new Category()
            {
                Id = dto.Id,
                Name = dto.Name,
                Books = dto.Books
            };
        }
    }
}
