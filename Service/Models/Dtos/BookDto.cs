using Libreria.Models.Entities;

namespace Libreria.Service.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string PublishingDate { get; set; } = string.Empty;
        public string Editor { get; set; } = string.Empty;
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
