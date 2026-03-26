using FluentValidation;

namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class CriarEscalaRequestValidator : AbstractValidator<CriarEscalaRequest>
{
    public CriarEscalaRequestValidator()
    {
        RuleFor(x => x.NomesFuncionarios)
            .NotEmpty()
            .WithMessage("Informe os nomes dos funcionários.");

        RuleFor(x => x.NomesFuncionarios.Count)
            .GreaterThanOrEqualTo(5)
            .WithMessage("A escala precisa ter no mínimo 5 funcionários.");

        RuleFor(x => x.NomesFuncionarios.Count)
            .LessThanOrEqualTo(10)
            .WithMessage("A escala pode ter no máximo 10 funcionários.");
    }
}