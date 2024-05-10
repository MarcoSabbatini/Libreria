namespace Libreria.Models.Entities
{
    public class Book : Entity
    {
        public int IdBook { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string PublishingDate { get; set; } = string.Empty;
        public string Editor { get; set; } = string.Empty;
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public Book(string name)
        {
            Name = name;
        }
    }
}
