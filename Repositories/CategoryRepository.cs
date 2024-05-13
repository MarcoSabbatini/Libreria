using Libreria.Models.Context;
using Libreria.Models.Entities;

namespace Libreria.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public override Category? Get(int id)
        {
            return _ctx.Categories
                .FirstOrDefault(c => c.Id == id);
        }

        public override bool Delete(int id)
        {

        }

    }
}
