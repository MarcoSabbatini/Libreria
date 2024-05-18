using FluentValidation;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Libreria.Service.Models.Requests;

namespace Libreria.Service.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator() {
            RuleFor(c => c.Filters)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("La ricerca deve avvenire con almeno un filtro applicato");

            RuleFor(c => c.FilterCategories)
                .Custom(SerchingValidation);
        }

        private void SerchingValidation(ICollection<Category> collection, ValidationContext<BookRequest> context)
        {
            if(context.InstanceToValidate
                .Filters
                .Contains(SearchFilters.CATEGORY)) {
                context.AddFailure("La ricerca usando il filtro Categoria deve avvenire con almeno una categoria inserita");
            }
        }
    }
}
