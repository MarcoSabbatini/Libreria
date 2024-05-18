using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;

namespace Libreria.Service.Models.Requests
{
    public class BookRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishingDate { get; set; } = DateTime.MinValue;
        public ICollection<Category> FilterCategories { get; set; } = new List<Category>();
        public ICollection<SearchFilters> Filters { get;} = new List<SearchFilters>();
        
    }
}
