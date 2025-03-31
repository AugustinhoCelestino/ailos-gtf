using Questao5.Application.Abstractions.Idempotency;

namespace Questao5.Application.Movimentacao.Commands;

public sealed record CreateMovimentacaoCommand(
    Guid IdRequisicao,
    Guid IdContaCorrente,
    decimal Valor,
    string TipoMovimento) : IdempotentCommand(IdRequisicao);