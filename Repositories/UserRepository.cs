using Libreria.Models.Context;
using Libreria.Models.Entities;
using Libreria.Service.Models.AuthOptions;

namespace Libreria.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(MyDbContext ctx) : base(ctx) { }

        /*public override User? Get(int id)
        {
            return _ctx.Users
                .FirstOrDefault(u => u.Id == id);
        }*/

        public User? Get(Credentials credentials)
        {
            return _ctx.Users
                .Where(u => u.Email == credentials.email)
                .FirstOrDefault(u => u.Password == credentials.password);
        }

        public bool CheckIfUnique(string email)
        {
            return !_ctx.Users
                .Any(u => u.Email == email);
        }
    }
}
