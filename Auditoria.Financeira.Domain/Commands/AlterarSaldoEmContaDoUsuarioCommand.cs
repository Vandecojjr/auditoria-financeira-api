using System;
using Auditoria.Financeira.Domain.Commands.Contratos;
using Auditoria.Financeira.Domain.Validations;

namespace Auditoria.Financeira.Domain.Commands;

public class AlterarSaldoEmContaDoUsuarioCommand : ICommand
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    
    public bool Validar()
    {
        return new AlterarSaldoEmContaDoUsuarioCommandValidator().Validate(this).IsValid;
    }
}