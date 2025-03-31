using Questao5.Application.Abstractions.Messaging;
using Questao5.Domain.Repositories;
using Questao5.Domain.Shared;

namespace Questao5.Application.Movimentacao.Commands;

internal sealed class CreateMovimentacaoCommandHandler : ICommandHandler<CreateMovimentacaoCommand>
{
    private readonly IContaCorrenteRepository _contaCorrenteRepository;
    private readonly IMovimentacaoRepository _movimentacaoRepository;

    public CreateMovimentacaoCommandHandler(IContaCorrenteRepository contaCorrenteRepository, IMovimentacaoRepository movimentacaoRepository)
    {
        _contaCorrenteRepository = contaCorrenteRepository;
        _movimentacaoRepository = movimentacaoRepository;
    }

    public async Task<Result> Handle(CreateMovimentacaoCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.ContaCorrente contaCorrente = await _contaCorrenteRepository.GetByIdAsync(request.IdContaCorrente);

        if (contaCorrente == null)
        {
            return Result.Failure(new Error("INVALID_ACCOUNT", "Apenas contas correntes cadastradas podem receber movimentação."));
        }
        if (contaCorrente.Ativo != 1)
        {
            return Result.Failure(new Error("INACTIVE_ACCOUNT", "Apenas contas correntes ativas podem receber movimentação"));
        }
        if (request.Valor <= 0)
        {
            return Result.Failure(new Error("INVALID_VALUE", "Apenas valores positivos podem ser recebidos"));
        }
        if (!(request.TipoMovimento.Equals("D") || request.TipoMovimento.Equals("C")))
        {
            return Result.Failure(new Error("INVALID_TYPE", "Apenas os tipos “débito” ou “crédito” podem ser aceitos. (C = Credito, D = Débito)"));
        }

        Domain.Entities.Movimentacao movimentacao = new()
        {
            IdContacorrente = request.IdContaCorrente,
            TipoMovimento = request.TipoMovimento,
            Valor = request.Valor,
            DataMovimento = DateTime.Now.ToString()
        };

        Domain.Entities.Movimentacao movimentacaoInserida = await _movimentacaoRepository.Add(movimentacao);

        return Result.Success();
    }
}