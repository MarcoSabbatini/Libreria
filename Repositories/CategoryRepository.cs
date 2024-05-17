using Libreria.Models.Context;
using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;

namespace Libreria.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public override void Delete(int id)
        {
            if (_ctx.Categories
                .FirstOrDefault(c => c.Id == id)
                .Books.Count == 0)
            {
                return;
            }
            base.Delete(id);
        }

        public override void Add(Category entity)
        {
            if(_ctx.Categories
                .Any(x => x.Name == entity.Name))
            {
                return;    
            }
            base.Add(entity);
        }

    }
}
