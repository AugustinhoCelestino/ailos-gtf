using AutoMapper;
using Questao5.Application.MovimentacaoContaCorrente;

namespace Questao5.Infrastructure.Services.Controllers.MovimentacaoContaCorrente
{
    public class MovimentacaoContaCorrenteProfile : Profile
    {
        public MovimentacaoContaCorrenteProfile()
        {
            CreateMap<MovimentacaoContaCorrenteRequest, MovimentacaoContaCorrenteCommand>();
            CreateMap<MovimentacaoContaCorrenteResult, MovimentacaoContaCorrenteResponse>();
        }
    }
}
