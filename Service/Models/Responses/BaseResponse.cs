namespace Libreria.Service.Models.Responses
{
    public class BaseResponse<T>
    {

        public T Success { get; set; }
        public T? Result { get; set; } = default;

    }
}
