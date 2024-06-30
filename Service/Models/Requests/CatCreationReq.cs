using Libreria.Models.Entities;

namespace Libreria.Service.Models.Requests
{
    public class CatCreationReq : GenericReq<Category>
    {
        public string Name { get; set; } = String.Empty;

        public Category EntityCreation()
        {
            return new Category() { Name = this.Name};
        }
    }
}
