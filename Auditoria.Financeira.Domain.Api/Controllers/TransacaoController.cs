using System.Security.Claims;
using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Handlers;
using Auditoria.Financeira.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation(Summary = "Cadastra transações", Description = "Tipo : {Debito = 0, Saque = 1, Compra = 2}.")]
    public ResultadoGenericoGenericoCommand Criar([FromBody] CriarTransacaoCommand command)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        command.UsuarioId = Guid.Parse(usuarioId);
        return (ResultadoGenericoGenericoCommand)_handler.Handle(command);
    }
    
    [Route("")]
    [HttpGet]
    [SwaggerOperation(Summary = "Obtém todas as transações", Description = "Tipo : {Debito = 0, Saque = 1, Compra = 2}.")]
    public IEnumerable<Transacao> BuscarTodos([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        return _transacaoRepository.BuscarTodas(Guid.Parse(usuarioId), skip, take);
    }
    
    [Route("buscar-por-periodo")]
    [HttpGet]
    [SwaggerOperation(Summary = "Obtém transações por periodo", Description = "Tipo : {Debito = 0, Saque = 1, Compra = 2}.")]
    public IEnumerable<Transacao> BuscarPorPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal,
        [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        return _transacaoRepository.BuscarPorPeriodo(dataInicial, dataFinal, Guid.Parse(usuarioId), skip, take);
    }
    
    [Route("buscar-por-tipo-de-transacao")]
    [HttpGet]
    [SwaggerOperation(Summary = "Obtém transações por tipo de transação", Description = "Tipo : {Debito = 0, Saque = 1, Compra = 2}.")]
    public IEnumerable<Transacao> BuscarPorTipo([FromQuery] TipoDaTransacao tipo,
        [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        return _transacaoRepository.BuscarPorTipo(tipo, Guid.Parse(usuarioId), skip, take);
    }
}
