using Libreria.Service.Actions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Requests;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Abstraction
{
    public interface IBookService
    {
        public LibraryModificationResponse LibraryModification(BookDto dto, BookAction action);

        public List<BookResponse> GetBooks(BookRequest request);
    }
}
