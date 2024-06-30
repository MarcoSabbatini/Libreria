using Libreria.Models.Entities;
using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Abstraction
{
    public interface IUserService
    {
        public void Add(User user);
    }
}
