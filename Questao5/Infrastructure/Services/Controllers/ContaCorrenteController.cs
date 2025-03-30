using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.MovimentacaoContaCorrente;
using Questao5.Infrastructure.Services.Controllers.MovimentacaoContaCorrente;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContaCorrenteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Movimentacao")]
        public async Task<IActionResult> MovimentacaoContaCorrente([FromBody] MovimentacaoContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok();
        }
    }
}
