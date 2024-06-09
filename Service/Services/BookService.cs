using Libreria.Models.Entities;
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
        private readonly CategoryRepository _categoryRepository;
        private readonly BookRepository _bookRepository;
        private readonly BookFactory _bookFactory;

        public BookService(CategoryRepository categoryRepository, BookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _bookFactory = new BookFactory();
        }

        public LibraryModificationResponse LibraryModification(BookDto dto, BookActions action)
        {

            var book = this._bookFactory.CreateEntity(dto, this._bookRepository.GetNewId());
            switch (action)
            {

                case BookActions.ADD:
                    var success = false;
                    foreach (var item in dto.Categories)
                    {
                        if (this._categoryRepository.Get(item.Id) != null)
                        {
                            this._categoryRepository.Add(item);
                        }

                    }
                    return new LibraryModificationResponse()
                    {
                        BookAction = action,
                        Success = this._bookRepository.Add(book),
                        Result = book
                    };

                case BookActions.DELETE:
                    var success1 = this._bookRepository.Delete(dto.Id);
                    return new LibraryModificationResponse()
                    {
                        BookAction = action,
                        Success = success1,
                        Result = book
                    };

                case BookActions.MODIFY:
                    var success2 = this._bookRepository.Get(dto.Id);
                    if (success2 == null)
                    {
                        return new LibraryModificationResponse()
                        {
                            BookAction = action,
                            Success = false,
                            Result = success2
                        };
                    }
                    this._bookRepository.Modify(book);
                    return new LibraryModificationResponse()
                    {
                        BookAction = action,
                        Success = true,
                        Result = this._bookRepository.Get(dto.Id)
                    };
            }
            return null;
        }

        public BookSearchingResponse GetBooks(BookRequest request)
        {
            ICollection<Book> books = [];
            books = this._bookRepository.GetAllByFilter(request);

            return new BookSearchingResponse()
            {
                Success = books == null ? false : true,
                Result = books
            };
        }

    }
}
