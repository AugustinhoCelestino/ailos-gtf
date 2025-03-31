using Questao5.Application.Abstractions.Messaging;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;
using Questao5.Domain.Shared;

namespace Questao5.Application.ContaCorrente.Queries;

internal sealed class ConsultaSaldoQueryHandler : IQueryHandler<ConsultaSaldoQuery, ConsultaSaldoResponse>
{
    private readonly IContaCorrenteRepository _contaCorrenteRepository;
    private readonly IMovimentacaoRepository _movimentacaoRepository;

    public ConsultaSaldoQueryHandler(IContaCorrenteRepository contaCorrenteRepository, IMovimentacaoRepository movimentacaoRepository)
    {
        _contaCorrenteRepository = contaCorrenteRepository;
        _movimentacaoRepository = movimentacaoRepository;
    }

    public async Task<Result<ConsultaSaldoResponse>> Handle(ConsultaSaldoQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.ContaCorrente contaCorrente = await _contaCorrenteRepository.GetByIdAsync(request.Id);

        if (contaCorrente == null)
        {
            return Result.Failure<ConsultaSaldoResponse>(new Error("INVALID_ACCOUNT", "Apenas contas correntes cadastradas podem consultar o saldo."));
        }
        if (contaCorrente.Ativo != 1)
        {
            return Result.Failure<ConsultaSaldoResponse>(new Error("INACTIVE_ACCOUNT", "Apenas contas correntes ativas podem consultar o saldo"));
        }

        List<Domain.Entities.Movimentacao> listaMovimentacaos = await _movimentacaoRepository.FindAllByAccountId(request.Id);

        decimal somaDebitos = listaMovimentacaos.Where(w => w.TipoMovimento == "D").Sum(s => s.Valor);
        decimal somaCreditos = listaMovimentacaos.Where(w => w.TipoMovimento == "C").Sum(s => s.Valor);

        decimal saldo = somaCreditos - somaDebitos;

        ConsultaSaldoResponse response = new(contaCorrente.Numero, contaCorrente.Nome, DateTime.Now.ToString(), saldo);
        
        return response;
    }
}
