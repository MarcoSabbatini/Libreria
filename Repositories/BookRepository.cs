using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Libreria.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(MyDbContext ctx) : base(ctx) { }
        public override Book? Get(int id) {
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

        public List<Book> GetAllByFilter(Dictionary<SearchFilters, string> dictionary)
        {
            if (dictionary.Count == 0) return null;
            
            IQueryable<Book> query = _ctx.Books;

            foreach (var filter in dictionary)
            {
                switch (filter.Key)
                {
                    case SearchFilters.CATEGORY:
                        query = query.Where(x => x.Categories.Any(c => c.Name.Equals(filter.Value)));
                        break;
                    case SearchFilters.NAME:
                        query = query.Where(x => x.Name.Equals(filter.Value));
                        break;
                    case SearchFilters.AUTHOR:
                        query = query.Where(x => x.Author.Equals(filter.Value));
                        break;
                    case SearchFilters.PUBLISHINGDATE:
                        // Converti il valore della data da stringa a DateTime
                        DateTime publishingDate;
                        if (DateTime.TryParse(filter.Value, out publishingDate))
                        {
                            query = query.Where(x => x.PublishingDate == publishingDate);
                        }
                        break;
                    default:
                        break;
                }
            }

            return query.ToList();
        }



    }

    public List<Book> GetAllByCategories(string name)
        {
            return GetAll()
                .Where(x => x.Categories.Contains(new Category(name)))
                .ToList();
        }
    }
}
