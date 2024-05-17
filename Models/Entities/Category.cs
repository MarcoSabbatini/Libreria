namespace Libreria.Models.Entities
{
    public class Category : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Category(string name) { Name = name; }
    }
}
