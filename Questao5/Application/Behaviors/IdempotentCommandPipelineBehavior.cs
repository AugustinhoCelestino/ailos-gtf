using MediatR;
using Questao5.Application.Abstractions.Idempotency;

namespace Questao5.Application.Behaviors;

internal sealed class IdempotentCommandPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IdempotentCommand
{
    private readonly IIdempotencyService _idempotencyService;

    public IdempotentCommandPipelineBehavior(IIdempotencyService idempotencyService)
    {
        _idempotencyService = idempotencyService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(await _idempotencyService.RequestExistsAsync(request.IdRequisicao))
        {
            return default;
        }
        await _idempotencyService.CreateRequestAsync(request.IdRequisicao, typeof(TRequest).Name);

        var response = await next();

        return response;
    }
}
