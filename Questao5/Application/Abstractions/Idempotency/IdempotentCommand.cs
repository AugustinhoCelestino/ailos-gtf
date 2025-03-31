using MediatR;

namespace Questao5.Application.Abstractions.Idempotency;

public abstract record IdempotentCommand(Guid IdRequisicao) : IRequest;

