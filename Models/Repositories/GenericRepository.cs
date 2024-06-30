using Libreria.Models.Context;
using Libreria.Models.Entities;

namespace Libreria.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public virtual void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            Save();
        }

        public void Modify(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public virtual T? Get(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
                _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
