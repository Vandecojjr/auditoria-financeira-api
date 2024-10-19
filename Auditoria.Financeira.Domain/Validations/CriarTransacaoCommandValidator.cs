using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Validations.Mensagens;
using FluentValidation;

namespace Auditoria.Financeira.Domain.Validations;

public class CriarTransacaoCommandValidator : AbstractValidator<CriarTransacaoCommand>
{
    public CriarTransacaoCommandValidator()
    {
        RuleFor(x => x.Valor)
            .GreaterThan(0)
            .WithMessage(TransacaoErrorMessages.ValorInvalido);
        
        RuleFor(x => x.Tipo)
            .IsInEnum()
            .WithMessage(TransacaoErrorMessages.TipoInvalido);
    }
}