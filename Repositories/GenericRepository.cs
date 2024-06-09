using Libreria.Models.Context;
using Libreria.Models.Entities;

namespace Libreria.Repositories
{
    public abstract class GenericRepository<T> where T : Entity
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public virtual bool Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            return Get(entity.Id).Equals(entity.Id);
        }

        public void Modify(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public virtual T? Get(int id)
        {
            return _ctx.Set<T>().
                Where(x => x.Id == id).
                FirstOrDefault();

        }

        public virtual bool Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
                _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return Get(entity.Id).Equals(entity.Id);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public int GetNewId()
        {
            var first = _ctx.Set<T>()
                .OrderBy(x => x.Id)
                .Reverse().FirstOrDefault();
            if (first != null)
                return first.Id + 1;
            else return 1;
        }
    }
}
