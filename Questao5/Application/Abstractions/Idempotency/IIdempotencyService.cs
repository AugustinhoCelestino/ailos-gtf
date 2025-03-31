namespace Questao5.Application.Abstractions.Idempotency;

public interface IIdempotencyService
{
    Task<bool> RequestExistsAsync(Guid idRequisicao);
    Task CreateRequestAsync(Guid idRequisicao, string nome);
}
