using FluentValidation;
using szerzodeskezelo_api.Models;

public class SzerzodesDtoValidator : AbstractValidator<SzerzodesDto>
{
    public SzerzodesDtoValidator()
    {
        RuleFor(x => x.Azonosito)
            .NotEmpty().WithMessage("Az azonosító megadása kötelező.");

        RuleFor(x => x.UgyfelId)
            .NotEmpty().WithMessage("Az ügyfél azonosító megadása kötelező.");

        RuleFor(x => x.KotesDatuma)
            .NotEmpty().WithMessage("A kötés dátuma megadása kötelező.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("A kötés dátuma nem lehet jövőbeli.");

        RuleFor(x => x.LejaratDatuma)
            .GreaterThanOrEqualTo(x => x.KotesDatuma)
            .When(x => x.LejaratDatuma.HasValue)
            .WithMessage("A lejárat dátuma nem lehet korábbi, mint a kötés dátuma.");

        RuleFor(x => x.Osszeg)
            .GreaterThan(0).WithMessage("Az összegnek pozitív számnak kell lennie.");

        RuleFor(x => x.Megjegyzes)
            .MaximumLength(500).WithMessage("A megjegyzés legfeljebb 500 karakter lehet.");
    }
}