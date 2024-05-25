namespace Libreria.Service.Models.Responses
{
    public class BaseResponse<T, K>
    {

        public T Success { get; set; }
        public K? Result { get; set; } = default;

    }
}
