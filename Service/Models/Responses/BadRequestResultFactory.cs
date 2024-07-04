using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Service.Models.Responses
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory(ActionContext context) : base(new BaseResponse<bool>() { Success = false })
        {
            var retErrors = new List<String>();
            foreach (var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                for (var i = 0; i < errors.Count; i++)
                {
                    retErrors.Add(errors[0].ErrorMessage);
                }
            }

            var response = (BaseResponse<bool>)Value;
            response.Errors = retErrors;
            response.Result = false;
        }
    }
}
