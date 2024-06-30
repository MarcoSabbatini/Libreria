using Libreria.Models.Context;
using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Models.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public ICollection<Book>? Delete(int id)
        {
            var category = _ctx.Categories.FirstOrDefault(c => c.Id == id);
            return category.Books.Count == 0 ? category.Books : null;
        }

        public override Category? Get(int id)
        {
            try
            {
                return _ctx.Categories.Where(x => x.Id == id).Include(x => x.Books).First();
            }
            catch
            {
                throw new Exception("Non esiste nessuna categoria con questo id");
            }
        }

        public Category Get(string name) 
        {
            return _ctx.Categories.Where(x => x.Name == name).First();       
        }


    }
}
