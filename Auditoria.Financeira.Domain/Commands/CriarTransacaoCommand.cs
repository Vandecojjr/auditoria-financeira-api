using System;
using Auditoria.Financeira.Domain.Commands.Contratos;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Validations;

namespace Auditoria.Financeira.Domain.Commands;

public class CriarTransacaoCommand : ICommand
{
    public CriarTransacaoCommand()
    {
    }

    public CriarTransacaoCommand(decimal valor, TipoDaTransacao tipo, DateTime data)
    {
        Valor = valor;
        Tipo = tipo;
    }

    public decimal Valor { get; set; }
    public TipoDaTransacao Tipo { get; set; }
    
    public bool Validar()
    {
       return new CriarTransacaoCommandValidator().Validate(this).IsValid;
    }
}