using FluentValidation;
using Questao5.Domain.Validators;

namespace Questao5.Infrastructure.Services.Controllers.MovimentacaoContaCorrente;

public class MovimentacaoContaCorrenteRequestValidator : AbstractValidator<MovimentacaoContaCorrenteRequest>
{
    public MovimentacaoContaCorrenteRequestValidator()
    {
        RuleFor(x => x.IdRequisicao)
           .NotEmpty()
           .WithMessage("IdRequisicao is required");

        RuleFor(x => x.ContaCorrenteId)
           .NotEmpty()
           .WithMessage("ContaCorrenteId is required");

        RuleFor(x => x.ValorMovimentacao)
           .NotEmpty()
           .WithMessage("ValorMovimentacao is required");

        RuleFor(x => x.TipoMovimentacao)
           .SetValidator(new TipoMovimentacaoValidator());
    }
}
