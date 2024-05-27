using System.Security.Claims;

namespace Libreria.Service.Models.Responses
{
    public class AAAResponse : BaseResponse<bool, string>
    {
        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}
