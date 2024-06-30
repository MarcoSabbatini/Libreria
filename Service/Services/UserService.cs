using Libreria.Models.Entities;
using Libreria.Models.Repositories;
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
        private readonly IConfiguration _configuration;


        public UserService(UserRepository userRepository/*, IOptions<JwtAuthenticationOption> jwtAuthenticationOption*/, IConfiguration configuration)
        {
            _userRepository = userRepository;
          //  _jwtAuthenticationOption = jwtAuthenticationOption.Value;
            _userFactory = new UserFactory();
            _configuration = configuration;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        /*public AAAResponse SignIn(Credentials credentials)
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
            if (/*this._userRepository.CheckIfUnique(userDto.Email)*//*true)
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
        }*/

        public string CreateSecurityToken(Credentials credentials)
        {
            // Ensure configuration values are not null
            var key = _configuration["JwtAuth:Key"];
            var issuer = _configuration["JwtAuth:Issuer"];
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer))
            {
                throw new ArgumentException("JWT configuration is missing required values.");
            }
            
            //JSON Web Token, security token used in authentication and authorization between two parties
            var jwtSecurityToken = new JwtSecurityToken(
                //Payload of a jwt 
                issuer: issuer,
                audience: issuer,
                claims: new List<Claim> {new Claim(JwtRegisteredClaimNames.Sub, credentials.email)},
                expires: DateTime.Now.AddHours(1),
                signingCredentials: CreateCredentials(key)
            );
            //writes the jwt into a jwebsignature or a jwencryption with encrypted payload
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        //initializes secret key
        private SigningCredentials CreateCredentials(string key)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
