using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Validations.Mensagens;
using FluentValidation;

namespace Auditoria.Financeira.Domain.Validations;

public class CriarUsuarioCommandValidator : AbstractValidator<CriarUsuarioCommand>
{
    public CriarUsuarioCommandValidator()
    {
        RuleFor(x=> x.Nome)
            .NotEmpty()
            .WithMessage(UsuarioErrorMessages.NomeVazio)
            .MinimumLength(6)
            .WithMessage(UsuarioErrorMessages.NomeComTamanhoInvalido);
        
        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage(UsuarioErrorMessages.SenhaVazia)
            .MinimumLength(6)
            .WithMessage(UsuarioErrorMessages.SenhaComTamanhoInvalido)
            .MaximumLength(32)
            .WithMessage(UsuarioErrorMessages.SenhaComTamanhoInvalido);
    }
}