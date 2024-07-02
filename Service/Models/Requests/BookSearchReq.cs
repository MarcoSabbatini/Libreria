using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using System.Diagnostics.Metrics;

namespace Libreria.Service.Models.Requests
{
    public class BookSearchReq : GenericReq<Book>
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime start { get; set; } = DateTime.MaxValue;
        public DateTime end { get; set; } = DateTime.MinValue;
        public ICollection<Category> categories { get; set; } = new List<Category>();
        public int? pageSize { get; set; } = 10;
        public int? pageCount { get; set; } = 0;

        public Book EntityCreation()
        {
            return new Book() 
            { 
                Author = this.Author, 
                Name = this.Name, 
                Categories = this.categories
            };
        }

        /**
         * Searching only 1 category at a time allowed
         */
        /*public string Category { get; set; } = string.Empty;

        public ICollection<SearchFilters> Filters { get; } = new List<SearchFilters>();
        */

        public bool ValidateFilters()
        {
            return !(Name == string.Empty && Author == string.Empty &&
                start == DateTime.MaxValue && end == DateTime.MinValue &&
                categories.Count() == 0);
        }

        
    }
}
