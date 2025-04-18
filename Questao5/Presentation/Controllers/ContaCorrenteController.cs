﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.ContaCorrente.Queries;
using Questao5.Application.Movimentacao.Commands;
using Questao5.Domain.Shared;
using Questao5.Presentation.Abstractions;

namespace Questao5.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ContaCorrenteController : ApiController
{
    public ContaCorrenteController(ISender sender) : base(sender) { }
  
    [HttpPost("Movimentacao")]
    public async Task<IActionResult> MovimentacaoContaCorrente([FromBody] CreateMovimentacaoCommand request, CancellationToken cancellationToken)
    {
        Result result = await Sender.Send(request, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet("ConsultaSaldo/{id}")]
    public async Task<IActionResult> ConsultaSaldo(string id, CancellationToken cancellationToken)
    {
        ConsultaSaldoQuery query = new(id);

        Result<ConsultaSaldoResponse> result = await Sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}
