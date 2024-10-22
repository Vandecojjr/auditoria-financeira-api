using Auditoria.Financeira.Domain.Commands.Contratos;

namespace Auditoria.Financeira.Domain.Handlers.Contratos;

public interface IHandler<T> where T : ICommand
{
    IResultadoGenericoCommand Handle(T command);
}