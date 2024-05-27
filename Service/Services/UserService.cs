using Libreria.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Options;
using Libreria.Service.Models.Responses;
using Microsoft.Extensions.Options;
using Libreria.Service.Factories;
using System.IdentityModel.Tokens.Jwt;

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

        }

        public AAAResponse SignIn(UserDto userDto)
        {
            if (this._userRepository.CheckIfUnique(userDto.Email)) {
                return new AAAResponse()
                {
                    Success = this._userRepository.Add(this._userFactory.CreateUser(userDto)),
                    Result = this._userRepository.Get(userDto.Id).Email,
                    Claims = 
                };
            } 
        }

        public JwtSecurityToken CreateSecurityToken()
        {
            return new JwtSecurityToken(this._jwtAuthenticationOption.Value, null, null,/* aggiungere i claim*/ DateTime.Now.AddHours(2), );
        }
    }
}
