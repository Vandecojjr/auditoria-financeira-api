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
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        command.UsuarioId = Guid.Parse(usuarioId);
        return (ResultadoGenericoGenericoCommand)_handler.Handle(command);
    }
    
    [Route("")]
    [HttpGet]
    public IEnumerable<Transacao> BuscarTodos([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        return _transacaoRepository.BuscarTodas(Guid.Parse(usuarioId), skip, take);
    }
    
    [Route("buscar-por-periodo")]
    [HttpGet]
    public IEnumerable<Transacao> BuscarPorPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal,
        [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        return _transacaoRepository.BuscarPorPeriodo(dataInicial, dataFinal, Guid.Parse(usuarioId), skip, take);
    }
    
    [Route("buscar-por-tipo-de-transacao")]
    [HttpGet]
    public IEnumerable<Transacao> BuscarPorTipo([FromQuery] TipoDaTransacao tipo,
        [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        return _transacaoRepository.BuscarPorTipo(tipo, Guid.Parse(usuarioId), skip, take);
    }
}
