using Libreria.Models.Entities.Actions;
using Libreria.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Factories;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Requests;
using Libreria.Service.Models.Responses;
using System.Reflection.Metadata.Ecma335;

namespace Libreria.Service.Services
{
    public class BookService : IBookService
    {
        private readonly UserRepository _userRepository;
        private readonly BookRepository _bookRepository;
        private readonly BookFactory _bookFactory;
        private CategoryFactory _categoryFactory;

        public BookService(UserRepository userRepository, BookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _bookFactory = new BookFactory();
            _categoryFactory = new CategoryFactory();
        }

        public LibraryModificationResponse LibraryModification(BookDto dto, BookActions action)
        {

            var book = this._bookFactory.CreateEntity(dto, this._bookRepository.GetNewId());
            switch (action) { 
                
                case BookActions.ADD:
                    var success0 = this._bookRepository.Add(book);
                    return new LibraryModificationResponse()
                    {
                        BookAction = action,
                        
                    };

                case BookActions.DELETE:
                    var success1 = this._bookRepository.Delete()
                    return new LibraryModificationResponse()
                    {
                        BookAction = action,
                    };

                case BookActions.MODIFY:
                    return new LibraryModificationResponse()
                    {
                        BookAction = action,
                    };
            }
            return null;
        }
        public List<BookSearchingResponse> GetBooks(BookRequest request)
        {
            throw new NotImplementedException();
        }
        
    }
}
