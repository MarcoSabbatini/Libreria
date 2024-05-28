using Libreria.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Options;
using Libreria.Service.Models.Responses;
using Microsoft.Extensions.Options;
using Libreria.Service.Factories;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Libreria.Models.Entities;

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
            var user = this._userRepository.Get(credentials);
            List<Claim> list = new List<Claim>();
            list.Add(new Claim(ClaimTypes.Email, user.Email));
            list.Add(new Claim(ClaimTypes.Name, user.Name));
            list.Add(new Claim(ClaimTypes.Surname, user.Surname));
            return new AAAResponse()
            {
                Success = user != null ? true : false,
                Result = list
            };  
        }

        public AAAResponse SignIn(UserDto userDto)
        {
            if (this._userRepository.CheckIfUnique(userDto.Email)) {
                List<Claim> list = new List<Claim>();
                list.Add(new Claim(ClaimTypes.Email, userDto.Email));
                list.Add(new Claim(ClaimTypes.Name, userDto.Name));
                list.Add(new Claim(ClaimTypes.Surname, userDto.Surname));
                return new AAAResponse()
                {
                    Success = this._userRepository.Add(this._userFactory.CreateUser(userDto)),
                    Result = list
                };
            }
            return new AAAResponse()
            {
                Success = false,
                Result = new List<Claim>()
            };
        }

        public JwtSecurityToken CreateSecurityToken()
        {
            return new JwtSecurityToken(this._jwtAuthenticationOption.Issuer, null, null, expires: DateTime.Now.AddHours(2), signingCredentials: CreateCredentials());
        }

        private SigningCredentials CreateCredentials()
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtAuthenticationOption.Key));
            return new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        } 
    }
}
