using Libreria.Models.Entities;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Responses;
using System.Security.Claims;

namespace Libreria.Service.Factories
{
    public class UserFactory
    {
        public User CreateUser(UserDto user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return new User()
            {
                Name = user.Name, Email = user.Email, 
                Surname = user.Surname, Password = user.Password, 
                Id = user.Id
            };
        }
        public AAAResponse GenerateResponse(User? user)
        {
            if (user is null)
            {
                return new AAAResponse()
                {
                    Response = "error"
                };
            } else
            {
                return new AAAResponse()
                {
                    Response = "success",
                    Claims = [
                        new Claim("Name", user.Name),
                        new Claim("Surname", user.Surname),
                        new Claim("Email", user.Email),
                        new Claim("Id", user.Id.ToString())
                        ]
                };
            }
        }
    }
}
