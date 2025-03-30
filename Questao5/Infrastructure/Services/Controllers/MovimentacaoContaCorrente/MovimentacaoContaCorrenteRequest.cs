namespace Questao5.Infrastructure.Services.Controllers.MovimentacaoContaCorrente
{
    public class MovimentacaoContaCorrenteRequest
    {
        public string IdRequisicao { get; set; } = string.Empty;
        public string ContaCorrenteId { get; set; } = string.Empty;
        public decimal ValorMovimentacao { get; set; }
        public string TipoMovimentacao { get; set; } = string.Empty;
    }
}
