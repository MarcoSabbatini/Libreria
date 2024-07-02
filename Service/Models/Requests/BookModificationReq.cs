using Libreria.Models.Entities;
using System.Security.Policy;

namespace Libreria.Service.Models.Requests
{
    public class BookModificationReq : GenericReq<Book>
    {
        public int? Id { get; set; }

        public string? Name { get; set; } = string.Empty;

        public string? Author { get; set; } = string.Empty;

        public string? Editor { get; set; } = string.Empty;

        public DateTime? PublishingDate { get; set; } = DateTime.MaxValue;

        public ICollection<BookCategoriesModReq>? categories { get; set; } = [];

        public Book EntityCreation()
        {
            var book = new Book();
            book.Id = Id;
            book.Name = Name;
            book.Author = Author;
            book.Editor = Editor;
            book.PublishingDate = (DateTime)PublishingDate;
            foreach (var item in categories)
            {
                book.Categories.Add(item.EntityCreation());
            }
            return book;
        }
    }
}
