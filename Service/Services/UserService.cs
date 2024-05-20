using Libreria.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Options;
using Libreria.Service.Models.Responses;
using Microsoft.Extensions.Options;

namespace Libreria.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private UserFactory _userFactory;
        private readonly JwtAuthenticationOption _jwtAuthenticationOption;
        public UserService(UserRepository userRepository, IOptions<JwtAuthenticationOption> jwtAuthenticationOption)
        {
            _userRepository = userRepository;
            _jwtAuthenticationOption = jwtAuthenticationOption.Value;
            _userFactory = new UserFactory();
        }
        public AAAResponse Authentication(Credentials credentials)
        {
            throw new NotImplementedException();
        }

        public AAAResponse SignIn(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
