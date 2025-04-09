using FluentValidation;
using ugyfelkezelo_api.Models;

public class UgyfelDtoValidator : AbstractValidator<UgyfelDto>
{
    public UgyfelDtoValidator()
    {
        RuleFor(x => x.Nev)
            .NotEmpty().WithMessage("A név megadása kötelező.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Az email cím megadása kötelező.")
            .EmailAddress().WithMessage("Érvénytelen email formátum.");

        RuleFor(x => x.Telefonszam)
            .NotEmpty().WithMessage("A telefonszám megadása kötelező.");
    }
}