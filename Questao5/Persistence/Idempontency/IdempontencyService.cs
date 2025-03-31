using Questao5.Application.Abstractions.Idempotency;

namespace Questao5.Persistence.Idempontency;

internal sealed class IdempontencyService : IIdempotencyService
{
    public Task CreateRequestAsync(Guid idRequisicao, string nome)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RequestExistsAsync(Guid idRequisicao)
    {
        throw new NotImplementedException();
    }
}
