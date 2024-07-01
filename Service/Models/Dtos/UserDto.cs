using Libreria.Models.Entities;

namespace Libreria.Service.Models.Dtos
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Id { get; set; }

        public static UserDto toDTO(User user)
        {
            return new UserDto()
            {
                Id = (int)user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
