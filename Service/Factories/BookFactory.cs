using Libreria.Models.Entities;
using Libreria.Service.Models.Dtos;

namespace Libreria.Service.Factories
{
    public class BookFactory
    {
        public Book CreateEntity(BookDto dto, int id)
        {
            return new Book()
            {
                Id = id,
                Name = dto.Name,
                PublishingDate = dto.PublishingDate,
                Author = dto.Author,
                Editor = dto.Editor,
                Categories = dto.Categories
            };
        }
    }
}
