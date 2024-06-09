using FluentValidation;
using Libreria.Service.Models.Dtos;

namespace Libreria.Service.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(c => c.Categories)
                .NotEmpty()
                .WithMessage("Il parametro non può essere vuoto");
        }
    }
}
