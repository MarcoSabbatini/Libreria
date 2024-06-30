using Libreria.Models.Entities;
using Libreria.Service.Models.Dtos;
using System.Globalization;

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
                PublishingDate = DateTime.ParseExact(dto.PublishingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Author = dto.Author,
                Editor = dto.Editor,
                Categories = dto.Categories
            };
        }
    }
}
