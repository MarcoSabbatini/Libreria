using FluentValidation;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Libreria.Service.Models.Requests;

namespace Libreria.Service.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator() {
            //controlla se è stato inserito almen(o un filtro tra quelli nell'enum
            RuleFor(c => c.Filters)
                .NotEmpty()
                .IsInEnum()
                .Custom(SearchingValidation);
            //    .WithMessage("La ricerca deve avvenire con almeno un filtro applicato");
            /*
            RuleFor(c => c.FilterCategories)
                .Custom(SerchingValidation);*/
        }

        private void SearchingValidation(ICollection<SearchFilters> collection, ValidationContext<BookRequest> context)
        {
            if(context.InstanceToValidate.Filters.Contains(SearchFilters.CATEGORY) &&
                context.InstanceToValidate.Category.Length < 1) 
            {
                context.AddFailure("La ricerca usando il filtro Categoria deve contenere almeno un carattere");
            } else if(context.InstanceToValidate.Filters.Contains(SearchFilters.PUBLISHINGDATE) &&
                context.InstanceToValidate.PublishingDate.CompareTo(DateTime.Now) >= 0) 
            {
                context.AddFailure("La ricerca usando il filtro Data di publblicazione deve riportare una data precedente ad oggi");
            } else if(context.InstanceToValidate.Filters.Contains(SearchFilters.NAME) &&
                context.InstanceToValidate.Name.Length < 1)
            {
                context.AddFailure("La ricerca usando il filtro Nome deve contenere almeno un carattere");
            } else if (context.InstanceToValidate.Filters.Contains(SearchFilters.AUTHOR) &&
                context.InstanceToValidate.Author.Length < 1)
            {
                context.AddFailure("La ricerca usando il filtro Autore deve contenere almeno un carattere");
            }

        }
    }
}
