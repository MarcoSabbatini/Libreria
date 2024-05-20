using System.Security.Claims;

namespace Libreria.Service.Models.Responses
{
    public class AAAResponse : BaseResponse<bool>
    {
        public string Response { get; set; }
        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}
