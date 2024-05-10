namespace Libreria.Service.Models.AuthOptions
{
    public class Credentials
    {
        public string email;
        public string password;

        public Credentials(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
