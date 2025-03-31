using Questao5.Application.Abstractions.Messaging;

namespace Questao5.Application.ContaCorrente.Queries;

public sealed record ConsultaSaldoQuery(string Id) : IQuery<ConsultaSaldoResponse>;
