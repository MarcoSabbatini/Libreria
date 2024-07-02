using Libreria.Models.Entities;

namespace Libreria.Service.Models.Requests
{
    public class BookCategoriesModReq : GenericReq<Category>
    {
        public string Name {  get; set; }

        public Category EntityCreation()
        {
            return new Category()
            {
                Name = Name
            };
        }
    }
}
