using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Microsoft.EntityFrameworkCore;
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

        public List<Book> GetAllByFilter(Map)
        {

        }

        public List<Book> GetAllByCategory(string name)
        {
            return GetAll()
                .Where(x => x.Categories.Contains(new Category(name)))
                .ToList();
        }
    }
}
