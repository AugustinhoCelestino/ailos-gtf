using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories;

public interface IMovimentacaoRepository
{
    Task<Movimentacao> Add(Movimentacao movimentacao);
    Task<List<Movimentacao>> FindAllByAccountId(string id);
}
