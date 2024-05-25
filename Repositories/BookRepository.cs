using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Libreria.Service.Models.Requests;
using Microsoft.EntityFrameworkCore;
namespace Libreria.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(MyDbContext ctx) : base(ctx) { }
        public override Book? Get(int id) 
        {
            return _ctx.Books
            .Include(x => x.Name)
            .FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetAll()
        {
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
