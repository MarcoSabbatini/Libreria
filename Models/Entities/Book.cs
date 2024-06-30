namespace Libreria.Models.Entities
{
    public class Book 
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishingDate { get; set; } = DateTime.MinValue;
        public string Editor { get; set; } = string.Empty;
        public ICollection<Category> Categories { get; set; } = new List<Category>();

    }
}
