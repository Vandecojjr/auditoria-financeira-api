using System.Security.Claims;
using Auditoria.Financeira.Domain.Api.Service;
using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Handlers;
using Auditoria.Financeira.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Auditoria.Financeira.Domain.Api.Model;

namespace Auditoria.Financeira.Domain.Api.Controllers;

[ApiController]
[Route("v1/usuario")]
public class UsuarioController : ControllerBase
{
    
    private readonly AuditoriaFinanceiraHandler _handler;
    private readonly IUsuarioRepository _usuarioRepository;
    
    public UsuarioController(AuditoriaFinanceiraHandler handler,IUsuarioRepository usuarioRepository)
    {
        _handler = handler;
        _usuarioRepository = usuarioRepository;
    }
    
    [Route("")]
    [HttpPost]
    public ResultadoGenericoGenericoCommand Criar([FromBody] CriarUsuarioCommand command)
    {
        return (ResultadoGenericoGenericoCommand)_handler.Handle(command);
    }

    [Route("ver-saldo")]
    [HttpGet]
    [Authorize]
    public decimal VerSaldo()
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        return _usuarioRepository.BuscarPorId(Guid.Parse(usuarioId)).SaldoEmConta;
    }
    
    [HttpPost]
    [Route("login")]
    public ActionResult<dynamic> Login([FromBody] LoginModel modeloDeLogin )
    {
        
        var usuario = _usuarioRepository.BuscarPorNomeESenha(modeloDeLogin.Nome, modeloDeLogin.Senha);
        if(usuario == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });
        return TokenService.GenerateToken(usuario);
    }
}