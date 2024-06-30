using Libreria.Models.Entities;
using Libreria.Models.Entities.Actions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Requests;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Abstraction
{
    public interface IBookService
    {
        public ICollection<Book> GetAll();
        public Book Get(int id);
        public Book Modify(Book book);
        public void Add(Book book);
        public void Delete(int id);
        ICollection<Book> GetAllByFilter(Book book, DateTime after, DateTime before, int pageSize, int pageCount);
    }
}
