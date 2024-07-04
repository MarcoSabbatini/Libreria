using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Service.Models.AuthOptions;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Models.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(MyDbContext ctx) : base(ctx) { }

        public User? Get(string email, string password)
        {
            return _ctx.Users
                .Where(x => x.Email == email)
                .Where(x => x.Password == password).First();
        }

        public User? Get(string email)
        {
            return _ctx.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public bool CheckIfUnique(string email)
        {
            return !_ctx.Users
                .Any(u => u.Email == email);
        }
    }
}
