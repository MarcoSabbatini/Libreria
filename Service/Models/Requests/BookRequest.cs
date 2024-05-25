using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;

namespace Libreria.Service.Models.Requests
{
    public class BookRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishingDate { get; set; } = DateTime.MinValue;

        /**
         * Searching only 1 category at a time allowed
         */
        public string Category { get; set; } = string.Empty;

        public ICollection<SearchFilters> Filters { get;} = new List<SearchFilters>();
        
    }
}
