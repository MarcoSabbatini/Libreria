using FluentValidation;
using Libreria.Service.Models.Dtos;

namespace Libreria.Service.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Inserire una email.")
                .EmailAddress()
                .WithMessage("L'email deve essere un indirizzo email.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Inserire una password.")
                .MinimumLength(8)
                .WithMessage("La password deve essere lunga almeno 8 caratteri");
        }
    }
}
