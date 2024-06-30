using System.Text.Json.Serialization;

namespace Libreria.Models.Entities
{
    public class BookCategory
    {
        [JsonIgnore]//to avoid infinite loops
        public int idBook { get; set; }
        [JsonIgnore]//to avoid infinite loops
        public int idCategory { get; set; }
        [JsonIgnore]//to avoid infinite loops
        public Book book { get; set; } 
        [JsonIgnore]//to avoid infinite loops
        public Category category { get; set; } 
    }
}
