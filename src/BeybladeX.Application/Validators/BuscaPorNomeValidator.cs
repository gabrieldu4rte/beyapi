using FluentValidation;

namespace BeybladeX.Application.Validators;

public class BuscaPorNomeValidator : AbstractValidator<string>
{
    public BuscaPorNomeValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("O nome da peça não pode ser vazio.");

        RuleFor(x => x)
            .MaximumLength(120)
            .WithMessage("O nome não pode exceder 120 caracteres.");
    }
}
