namespace Questao5.Application.ContaCorrente.Queries;

public sealed record ConsultaSaldoResponse(int NumeroContaCorrente, string NomeTitular, string DataConsulta, decimal ValorSaldoAtual);