using Auditoria.Financeira.Domain.Commands.Contratos;

namespace Auditoria.Financeira.Domain.Commands;

public class AlterarSaldoEmContaDoUsuarioCommand : ICommand
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    
    public bool Validar()
    {
        throw new NotImplementedException();
    }
}