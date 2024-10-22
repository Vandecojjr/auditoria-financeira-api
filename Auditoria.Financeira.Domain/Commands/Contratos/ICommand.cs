using FluentValidation.Results;

namespace Auditoria.Financeira.Domain.Commands.Contratos;

public interface ICommand
{
    ValidationResult Validar();
} 