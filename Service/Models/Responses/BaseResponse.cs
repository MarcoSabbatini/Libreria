namespace Libreria.Service.Models.Responses
{
    public class BaseResponse<K>
    {

        public bool Success { get; set; }
        public K? Result { get; set; } = default;
        public List<string> Errors { get; set; } 

    }
}
