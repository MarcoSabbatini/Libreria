using Libreria.Models.Entities;
using Libreria.Models.Entities.Actions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Abstraction
{
    public interface ICategoryService
    {
        public void Add(Category category);
        public void Delete(int id);
        public Category Get(int id);
        public Category Get(string name);
    }
}
