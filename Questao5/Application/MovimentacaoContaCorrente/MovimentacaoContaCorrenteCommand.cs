using MediatR;

namespace Questao5.Application.MovimentacaoContaCorrente;

public class MovimentacaoContaCorrenteCommand : IRequest<MovimentacaoContaCorrenteResult>
{
    public string IdRequisicao { get; set; } = string.Empty;
    public string ContaCorrenteId { get; set; } = string.Empty;
    public decimal ValorMovimentacao { get; set; }
    public string TipoMovimentacao { get; set; } = string.Empty;

}
