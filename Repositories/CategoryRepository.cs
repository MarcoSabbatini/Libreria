using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Service.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;

namespace Libreria.Repositories
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

        public override bool Add(Category entity)
        {
            if(_ctx.Categories
                .Any(x => x.Name == entity.Name))
            {
                return false;    
            }
            return base.Add(entity);
        }

    }
}
