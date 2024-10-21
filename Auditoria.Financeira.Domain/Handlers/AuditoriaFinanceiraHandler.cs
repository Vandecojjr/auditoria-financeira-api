using System.Linq;
using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Commands.Contratos;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Handlers.Contratos;
using Auditoria.Financeira.Domain.Repositories;
using Auditoria.Financeira.Domain.Validations;

namespace Auditoria.Financeira.Domain.Handlers;

public class AuditoriaFinanceiraHandler : 
    IHandler<CriarUsuarioCommand>,
    IHandler<CriarTransacaoCommand>
{
    public readonly CriarUsuarioCommandValidator _criarUsuarioCommandValidator;
    public readonly CriarTransacaoCommandValidator _criarTransacaoCommandValidator;
    public readonly IUsuarioRepository _usuarioRepository;
    public readonly ITransacaoRepository _transacaoRepository;
    
    public AuditoriaFinanceiraHandler(CriarUsuarioCommandValidator criarUsuarioCommandValidator,
        CriarTransacaoCommandValidator criarTransacaoCommandValidator,
        IUsuarioRepository usuarioRepository,
        ITransacaoRepository transacaoRepository)    
    {
        _criarUsuarioCommandValidator = criarUsuarioCommandValidator;
        _criarTransacaoCommandValidator = criarTransacaoCommandValidator;
        _usuarioRepository = usuarioRepository;
        _transacaoRepository = transacaoRepository;
    }

    public IResultadoGenericoCommand Handler(CriarUsuarioCommand command)
    {
        var resultado = _criarUsuarioCommandValidator.Validate(command);
        if (!resultado.IsValid)
            return new ResultadoGenericoGenericoCommand(false,"Não foi possível criar o usuário", 
                    resultado.Errors.Select(x => x.ErrorMessage).ToList());
        
        var usuario = new Usuario(command.Nome, command.Senha, command.SaldoEmConta);
        _usuarioRepository.Criar(usuario);
        
        return new ResultadoGenericoGenericoCommand(true, "Usuário criado com sucesso", usuario);
    }

    public IResultadoGenericoCommand Handler(CriarTransacaoCommand command)
    {
        var resultado = _criarTransacaoCommandValidator.Validate(command);
        if (!resultado.IsValid)
            return new ResultadoGenericoGenericoCommand(false,"Não foi possível criar a transação", 
                    resultado.Errors.Select(x => x.ErrorMessage).ToList());
        
        var transacao = new Transacao(command.Valor, command.Tipo);
        _transacaoRepository.Criar(transacao);
        
        var usuario = _usuarioRepository.BuscarPorId(command.UsuarioId);
        usuario.AlterarSaldo(transacao.Tipo, transacao.Valor);
        _usuarioRepository.Atualizar(usuario);        
        
        return new ResultadoGenericoGenericoCommand(true, "Transação criada com sucesso", transacao);
    }
}