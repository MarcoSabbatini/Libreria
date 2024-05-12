namespace Libreria.Models.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public Category(string name) { Name = name; }
    }
}
