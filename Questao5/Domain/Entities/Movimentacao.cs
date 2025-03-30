namespace Questao5.Domain.Entities;

public class Movimentacao
{
    public string IdMovimentacao { get; set; } = string.Empty;
    public string IdContacorrente { get; set; } = string.Empty;
    public string DataMovimentacao { get; set; } = string.Empty;
    public string TipoMovimentacao { get; set; } = string.Empty;
    public decimal Valor { get; set; } = 0;
}
