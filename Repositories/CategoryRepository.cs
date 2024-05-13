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

        public override bool Delete(int id)
        {
            if(_ctx.Books.Include(x => x.Categories)
                .Where(x => x.))
            {
                base.(Delete)(id);
                JavaScriptEncoder.ReferenceEquals(privateclass)
            }
        }

    }
}
