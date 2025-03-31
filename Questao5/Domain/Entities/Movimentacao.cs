namespace Questao5.Domain.Entities;

public class Movimentacao
{
    public string IdMovimento { get; set; } = string.Empty;
    public string IdContacorrente { get; set; } = string.Empty;
    public string DataMovimento { get; set; } = string.Empty;
    public string TipoMovimento { get; set; } = string.Empty;
    public decimal Valor { get; set; } = 0;
}
