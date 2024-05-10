using Libreria.Models.Entities;

namespace Libreria.Service.Models.Dtos
{
    public class BookDto
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string PublishingDate { get; set; } = string.Empty;

        public BookDto() { }

        public BookDto(Book book)
        {
            Name = book.Name;
            Author = book.Author;
            PublishingDate = book.PublishingDate;
        }
    }
}
