using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Libreria.Service.Models.Requests;
using Microsoft.EntityFrameworkCore;
namespace Libreria.Models.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(MyDbContext ctx) : base(ctx) { }

        public override Book? Get(int id)
        {
            var book = base._ctx.Books
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if(book == null)
            {
                throw new Exception("Select another index, there are no books corresponding to this index");
            }
            var categories = base._ctx.Books
                .Where(x => x.Id ==  book.Id)
                .SelectMany(x => x.Categories)//takes all the categories appended(nested) to all the books
                .Select(x => new Category { Id = x.Id, Name = x.Name})//transforms each category object into a new category without the books nested 
                .Distinct()
                .ToList();
            book.Categories = categories;

            return book;
        }

        public List<Book> GetAll()
        {
            var books = base._ctx.Books.ToList();


            return _ctx.Books
                .Include(x => x.Categories)
                .ToList();
        }

        public List<Book> GetAllByFilter(BookRequest bookForFilters)
        {

            if (bookForFilters.Filters.Count == 0) return null;
            IQueryable<Book> query = _ctx.Books;

            foreach (var filter in bookForFilters.Filters)
            {
                switch (filter)
                {
                    case SearchFilters.CATEGORY:
                        query = query.Where(x => x.Categories.Any(c => c.Name.Equals(bookForFilters.Category)));
                        break;
                    case SearchFilters.NAME:
                        query = query.Where(x => x.Name.Equals(bookForFilters.Name));
                        break;
                    case SearchFilters.AUTHOR:
                        query = query.Where(x => x.Author.Equals(bookForFilters.Author));
                        break;
                    case SearchFilters.PUBLISHINGDATE:
                        query = query.Where(x => x.PublishingDate.Equals(bookForFilters.PublishingDate));
                        break;
                    default:
                        break;
                }
            }
            return query.ToList();
        }
    }
}
