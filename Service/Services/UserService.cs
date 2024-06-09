using Libreria.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Factories;
using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Options;
using Libreria.Service.Models.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Libreria.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private UserFactory _userFactory;
        //private readonly JwtAuthenticationOption _jwtAuthenticationOption;

        public UserService(UserRepository userRepository/*, IOptions<JwtAuthenticationOption> jwtAuthenticationOption*/)
        {
            _userRepository = userRepository;
          //  _jwtAuthenticationOption = jwtAuthenticationOption.Value;
            _userFactory = new UserFactory();
        }

        public AAAResponse SignIn(Credentials credentials)
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

        public AAAResponse SignUp(UserDto userDto)
        {
            if (/*this._userRepository.CheckIfUnique(userDto.Email)*/true)
            {
                List<Claim> list1 = new List<Claim>();
                list1.Add(new Claim(ClaimTypes.Email, userDto.Email));
                list1.Add(new Claim(ClaimTypes.Name, userDto.Name));
                list1.Add(new Claim(ClaimTypes.Surname, userDto.Surname));
                list1.Add(new Claim("Id", userDto.Id.ToString()));
                List<Claim> list = new List<Claim>();
                //list.Add(new Claim("Token", new JwtSecurityTokenHandler().WriteToken(this.CreateSecurityToken(list1))));
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

        /*public JwtSecurityToken CreateSecurityToken(ICollection<Claim> list)
        {
            return new JwtSecurityToken(this._jwtAuthenticationOption.Issuer, null, list, expires: DateTime.Now.AddHours(2), signingCredentials: CreateCredentials());
        }

        private SigningCredentials CreateCredentials()
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtAuthenticationOption.Key));
            return new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }*/
    }
}
