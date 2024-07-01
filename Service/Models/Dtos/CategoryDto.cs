using Libreria.Models.Entities;

namespace Libreria.Service.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static CategoryDto toDTO(Category category)
        {
            return new CategoryDto { Id = (int)category.Id, Name = category.Name};
        }
    }
}
