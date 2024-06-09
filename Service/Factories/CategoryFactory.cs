using Libreria.Models.Entities;
using Libreria.Service.Models.Dtos;

namespace Libreria.Service.Factories
{
    public class CategoryFactory
    {
        public Category CreateEntity(CategoryDto dto, int id)
        {
            return new Category()
            {
                Id = id,
                Name = dto.Name,
                Books = dto.Books
            };
        }
    }
}
