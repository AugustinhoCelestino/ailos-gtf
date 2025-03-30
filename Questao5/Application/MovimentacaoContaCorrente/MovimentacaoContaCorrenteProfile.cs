using AutoMapper;
using Questao5.Domain.Entities;

namespace Questao5.Application.MovimentacaoContaCorrente;

public class MovimentacaoContaCorrenteProfile : Profile
{
    public MovimentacaoContaCorrenteProfile()
    {
        CreateMap<MovimentacaoContaCorrenteCommand, Movimentacao>();
        CreateMap<Movimentacao, MovimentacaoContaCorrenteResult>();
    }
}
