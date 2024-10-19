using System.Linq;
using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Commands.Contratos;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Handlers.Contratos;
using Auditoria.Financeira.Domain.Validations;

namespace Auditoria.Financeira.Domain.Handlers;

public class AuditoriaFinanceiraHandler : 
    IHandler<CriarUsuarioCommand>,
    IHandler<CriarTransacaoCommand>,
    IHandler<AlterarSaldoEmContaDoUsuarioCommand>
{
    public readonly CriarUsuarioCommandValidator _criarUsuarioCommandValidator;
    public readonly CriarTransacaoCommandValidator _criarTransacaoCommandValidator;
    public readonly AlterarSaldoEmContaDoUsuarioCommandValidator _alterarSaldoEmContaDoUsuarioCommandValidator;
    
    public AuditoriaFinanceiraHandler(CriarUsuarioCommandValidator criarUsuarioCommandValidator,
        CriarTransacaoCommandValidator criarTransacaoCommandValidator,
        AlterarSaldoEmContaDoUsuarioCommandValidator alterarSaldoEmContaDoUsuarioCommandValidator)    
    {
        _criarUsuarioCommandValidator = criarUsuarioCommandValidator;
        _criarTransacaoCommandValidator = criarTransacaoCommandValidator;
        _alterarSaldoEmContaDoUsuarioCommandValidator = alterarSaldoEmContaDoUsuarioCommandValidator;
    }

    public IResultadoGenericoCommand Handler(CriarUsuarioCommand command)
    {
        var resultado = _criarUsuarioCommandValidator.Validate(command);
        if (!resultado.IsValid)
            return new ResultadoGenericoGenericoCommand(false,"Não foi possível criar o usuário", 
                    resultado.Errors.Select(x => x.ErrorMessage).ToList());
        
        var usuario = new Usuario(command.Nome, command.Senha, command.SaldoEmConta);
        return new ResultadoGenericoGenericoCommand(true, "Usuário criado com sucesso", usuario);
    }

    public IResultadoGenericoCommand Handler(CriarTransacaoCommand command)
    {
        var resultado = _criarTransacaoCommandValidator.Validate(command);
        if (!resultado.IsValid)
            return new ResultadoGenericoGenericoCommand(false,"Não foi possível criar a transação", 
                    resultado.Errors.Select(x => x.ErrorMessage).ToList());
        
        return new ResultadoGenericoGenericoCommand(true, "Transação criada com sucesso", null);
    }

    public IResultadoGenericoCommand Handler(AlterarSaldoEmContaDoUsuarioCommand command)
    {
        var resultado = _alterarSaldoEmContaDoUsuarioCommandValidator.Validate(command);
        if (!resultado.IsValid)
            return new ResultadoGenericoGenericoCommand(false," não foi possível alterar o saldo", 
                    resultado.Errors.Select(x => x.ErrorMessage).ToList());
        
        return new ResultadoGenericoGenericoCommand(true, "Saldo alterado com sucesso", null);
    }
}