using FluentValidation;

namespace Questao5.Domain.Validators
{
    public class TipoMovimentacaoValidator : AbstractValidator<string>
    {
        public TipoMovimentacaoValidator()
        {
            RuleFor(tipoMovimentacao => tipoMovimentacao)
                .NotEmpty()
                .Length(1)
                .Must(tipoMovimentacao => tipoMovimentacao == "D" || tipoMovimentacao == "C")
                .WithMessage("TipoMovimentacao deve ser C para crédito ou D para débito");
        }
    }
}
