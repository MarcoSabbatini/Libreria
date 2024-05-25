using Libreria.Models.Entities;
using Libreria.Models.Entities.Actions;
using Libreria.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Factories;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Responses;

namespace Libreria.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private CategoryFactory _categoryFactory;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryFactory = new CategoryFactory();
        }

        public CategoryModificationResponse CategoryModification(CategoryDto dto, CategoryActions action)
        {
            Category category = this._categoryFactory.CreateEntity(dto, this._categoryRepository.GetNewId());
            switch (action)
            {
                case CategoryActions.ADD:

                    var success0 = this._categoryRepository.Add(category);
                    if (success0)
                    {
                        return new CategoryModificationResponse()
                        {
                            CategoryAction = action,
                            Success = success0,
                            Result = category
                        };
                    } 
                    else
                    {
                        return new CategoryModificationResponse()
                        {
                            CategoryAction = action,
                            Success = success0,
                            Result = category, 
                            Name = category.Name
                        };
                    }
  

                case CategoryActions.DELETE:

                    var success1 = this._categoryRepository.Delete(dto.Id);
                    if (success1 == null)
                    {
                        return new CategoryModificationResponse()
                        {
                            CategoryAction = action,
                            Success = true,
                            Result = category
                        };
                    }
                    else
                    {
                        return new CategoryModificationResponse()
                        {
                            CategoryAction = action,
                            Success = false,
                            Result = category,
                            Books = success1
                        };
                    }
            }
            return null;

        }
    }
}
