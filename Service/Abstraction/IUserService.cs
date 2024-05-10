using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Abstraction
{
    public interface IUserService
    {
        public AAAResponse SignIn(UserDto userDto);

        public AAAResponse Authentication(Credentials credentials);
    }
}
