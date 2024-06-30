using Libreria.Models.Entities;

namespace Libreria.Service.Models.Requests
{
    public class UserCreationReq : GenericReq<User>
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;

        public User EntityCreation()
        {
            return new User()
            {
                Email = this.Email,
                Password = this.Password,
                Name = this.Name,
                Surname = this.Surname
            };
        }
    }
}
