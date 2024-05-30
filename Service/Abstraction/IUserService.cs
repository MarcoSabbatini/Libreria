using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Abstraction
{
    public interface IUserService
    {
        public AAAResponse SignUp(UserDto userDto);

        public AAAResponse SignIn(Credentials credentials);
    }
}
