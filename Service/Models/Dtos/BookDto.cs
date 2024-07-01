using Libreria.Models.Entities;

namespace Libreria.Service.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishingDate { get; set; } = DateTime.MinValue;
        public string Editor { get; set; } = string.Empty;
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public static BookDto toDTO(Book book)
        {
            var BookDto = new BookDto();
            BookDto.Id = (int)book.Id;
            BookDto.Name = book.Name;
            BookDto.Author = book.Author;
            BookDto.Editor = book.Editor;
            BookDto.PublishingDate = book.PublishingDate;
            foreach (var item in book.Categories)
            {
                var dto = CategoryDto.toDTO(item);
                BookDto.Categories.Add(dto);
            }
            return BookDto;
        }
    }
}
