using MediatR;
using Questao5.Application.Abstractions.Messaging;

namespace Questao5.Application.Movimentacao.Commands;

public sealed record CreateMovimentacaoCommand(
    string IdRequisicao,
    string IdContaCorrente,
    decimal Valor,
    string TipoMovimento) : ICommand;