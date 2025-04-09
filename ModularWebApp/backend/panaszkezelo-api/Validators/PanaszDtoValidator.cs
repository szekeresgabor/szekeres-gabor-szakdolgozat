using FluentValidation;
using panaszkezelo_api.Models;

public class PanaszDtoValidator : AbstractValidator<PanaszDto>
{
    public PanaszDtoValidator()
    {
        RuleFor(x => x.Cim).NotEmpty().WithMessage("A cím megadása kötelező.");
        RuleFor(x => x.Leiras).NotEmpty().WithMessage("A leírás megadása kötelező.");
        RuleFor(x => x.Statusz).NotEmpty().WithMessage("A státusz megadása kötelező.");
        RuleFor(x => x.BejelentesDatuma).NotEmpty().WithMessage("A bejelentés dátuma megadása kötelező.");
        RuleFor(x => x.UgyfelId).NotEmpty().WithMessage("Ügyfél kiválasztása kötelező.");
    }
}