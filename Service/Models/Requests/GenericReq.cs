namespace Libreria.Service.Models.Requests
{
    public interface GenericReq<T> where T : class
    {
        public T EntityCreation();
    }
}
