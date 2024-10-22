using System.Linq.Expressions;
using Auditoria.Financeira.Domain.Entities;

namespace Auditoria.Financeira.Domain.Queries;

public static class UsuarioQueries
{
    public static Expression<Func<Usuario, bool>> BuscarPorId(Guid id)
    {
        return x => x.Id == id;
    }
} 