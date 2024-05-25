using Libreria.Models.Entities.Actions;
using Libreria.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Factories;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Requests;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Services
{
    public class BookService : IBookService
    {
        private readonly UserRepository _userRepository;
        private readonly BookRepository _bookRepository;
        private readonly BookFactory _bookFactory;
        private CategoryFactory _categoryFactory;

        public List<BookSearchingResponse> GetBooks(BookRequest request)
        {
            throw new NotImplementedException();
        }

        public LibraryModificationResponse LibraryModification(BookDto dto, BookActions action)
        {
            throw new NotImplementedException();
        }
    }
}
