namespace Questao5.Domain.Entities;

public class Movimentacao
{
    public Guid IdMovimento { get; set; }
    public Guid IdContacorrente { get; set; }
    public string DataMovimento { get; set; } = string.Empty;
    public string TipoMovimento { get; set; } = string.Empty;
    public decimal Valor { get; set; } = 0;
}
