using FluentValidation;
using Libreria.Models.Entities.Common;
using Libreria.Service.Models.Requests;

namespace Libreria.Service.Validators
{
    public class BookRequestValidator : AbstractValidator<BookReq>
    {
        public BookRequestValidator()
        {
            //controlla se è stato inserito almeno un filtro tra quelli nell'enum
            RuleFor(x => x.start)
                .LessThan(x => x.end)
                .WithMessage("Starting date of the range has to be earlier than the end date of the range!");
            RuleFor(x => x.pageCount)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Pagecount not valid");
            RuleFor(x => x.pageSize)
                .NotNull()
                .NotEmpty()
                .GreaterThan(1)
                .WithMessage("Pagsize not valid");
        }
        /*
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
                        break;
                }
            }
        }*/

    }
}
