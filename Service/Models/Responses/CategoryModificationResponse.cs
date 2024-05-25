using Libreria.Models.Entities;
using Libreria.Models.Entities.Actions;

namespace Libreria.Service.Models.Responses
{
    public class CategoryModificationResponse : BaseResponse<bool, Category>
    {
        public CategoryActions CategoryAction { get; set; }
        public String Name { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
