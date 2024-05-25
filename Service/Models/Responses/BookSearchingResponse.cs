using Libreria.Models.Entities;

namespace Libreria.Service.Models.Responses
{
    public class BookSearchingResponse : BaseResponse<bool>
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
