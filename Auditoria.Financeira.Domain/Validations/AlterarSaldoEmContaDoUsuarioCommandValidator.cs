using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Validations.Mensagens;
using FluentValidation;

namespace Auditoria.Financeira.Domain.Validations;

public class AlterarSaldoEmContaDoUsuarioCommandValidator : AbstractValidator<AlterarSaldoEmContaDoUsuarioCommand>
{
     public AlterarSaldoEmContaDoUsuarioCommandValidator()
     {
          RuleFor(x => x.Valor)
               .GreaterThan(0)
               .WithMessage(SaldoEmContaDoUsuarioErrorMessages.ValorInvalido);
     }
}