using FluentValidation;
using Libreria.Models.Entities;
using Libreria.Models.Entities.Common;
using Libreria.Service.Models.Requests;

namespace Libreria.Service.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator() {
            //controlla se è stato inserito almeno un filtro tra quelli nell'enum
            RuleFor(c => c.Filters)
                .NotEmpty()
                .IsInEnum()
                .Custom(SearchingValidation);
        }

        private void SearchingValidation(ICollection<SearchFilters> collection, ValidationContext<BookRequest> context)
        {
            foreach (var filter in collection)
            {
                switch (filter)
                {
                    case SearchFilters.CATEGORY:
                        if (context.InstanceToValidate.Category.Length < 1)
                        {
                            context.AddFailure("La ricerca usando il filtro Categoria deve contenere almeno un carattere");
                        }
                        break;
                    case SearchFilters.PUBLISHINGDATE:
                        if (context.InstanceToValidate.PublishingDate.CompareTo(DateTime.Now) >= 0)
                        {
                            context.AddFailure("La ricerca usando il filtro Data di publblicazione deve riportare una data precedente ad oggi");
                        }
                        break;
                    case SearchFilters.NAME:
                        if (context.InstanceToValidate.Name.Length < 1)
                        {
                            context.AddFailure("La ricerca usando il filtro Nome deve contenere almeno un carattere");
                        }
                        break;
                    case SearchFilters.AUTHOR:
                        if (context.InstanceToValidate.Author.Length < 1)
                        {
                            context.AddFailure("La ricerca usando il filtro Autore deve contenere almeno un carattere");
                        }
                        break;
                    default:
                        // Ignora filtri non supportati
                        break;
                }
            }
        }

    }
}
