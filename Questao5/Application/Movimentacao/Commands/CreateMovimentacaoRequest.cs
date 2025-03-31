namespace Questao5.Application.Movimentacao.Commands;

public class CreateMovimentacaoRequest
{
    public Guid IdContaCorrente { get; set; }
    public decimal Valor { get; set; }
    public string TipoMovimento { get; set; } = string.Empty;
}
