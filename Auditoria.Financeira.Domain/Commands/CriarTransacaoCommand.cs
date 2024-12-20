using System;
using System.ComponentModel.DataAnnotations;
using Auditoria.Financeira.Domain.Commands.Contratos;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Validations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Auditoria.Financeira.Domain.Commands;

public class CriarTransacaoCommand : ICommand
{
    public CriarTransacaoCommand()
    {
    }

    public CriarTransacaoCommand(decimal valor, TipoDaTransacao tipo, Guid usuarioId)
    {
        UsuarioId = usuarioId;
        Valor = valor;
        Tipo = tipo;
    }

    public decimal Valor { get; set; }
    public TipoDaTransacao Tipo { get; set; }
    public Guid UsuarioId { get; set; }


    public ValidationResult Validar()
    {
        return new CriarTransacaoCommandValidator().Validate(this);
    }
}