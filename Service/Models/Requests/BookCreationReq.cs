using Libreria.Models.Entities;

namespace Libreria.Service.Models.Requests
{
    public class BookCreationReq : GenericReq<Book>
    {
        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Editor { get; set; } = string.Empty;

        public DateTime PublishingDate { get; set; } = DateTime.Now;

        public ICollection<CatCreationReq> categories { get; set; } = [];

        public Book EntityCreation()
        {
            var book = new Book();
            book.Name = Name;
            book.Author = Author;
            book.Editor = Editor;
            book.PublishingDate = PublishingDate;
            foreach (var item in categories)
            {
                book.Categories.Add(item.EntityCreation());
            }
            return book;
        }
    }
}
