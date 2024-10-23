using System.Security.Claims;
using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Handlers;
using Auditoria.Financeira.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auditoria.Financeira.Domain.Api.Controllers;

[Authorize]
[ApiController]
[Route("v1/transacao")]
public class TransacaoController : ControllerBase
{
    private readonly AuditoriaFinanceiraHandler _handler;
    private readonly ITransacaoRepository _transacaoRepository;
    
    public TransacaoController(AuditoriaFinanceiraHandler handler, ITransacaoRepository transacaoRepository)
    {
        _handler = handler;
        _transacaoRepository = transacaoRepository;
    }
    
    [Route("")]
    [HttpPost]
    public ResultadoGenericoGenericoCommand Criar([FromBody] CriarTransacaoCommand command)
    {
        return (ResultadoGenericoGenericoCommand)_handler.Handle(command);
    }
    
    [Route("")]
    [HttpGet]
    public IEnumerable<Transacao> BuscarTodos([FromQuery]Guid usuarioId,[FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _transacaoRepository.BuscarTodas(usuarioId, skip, take);
    }
    
    [Route("buscar-por-periodo")]
    [HttpGet]
    public IEnumerable<Transacao> BuscarPorPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal, [FromQuery] Guid usuarioId,
        [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _transacaoRepository.BuscarPorPeriodo(dataInicial, dataFinal, usuarioId, skip, take);
    }
    
    [Route("buscar-por-tipo-de-transacao")]
    [HttpGet]
    public IEnumerable<Transacao> BuscarPorTipo([FromQuery] TipoDaTransacao tipo, [FromQuery] Guid usuarioId,
        [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _transacaoRepository.BuscarPorTipo(tipo, usuarioId, skip, take);
    }
}
