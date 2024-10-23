using System.Linq.Expressions;
using Auditoria.Financeira.Domain.Entities;

namespace Auditoria.Financeira.Domain.Queries;

public static class UsuarioQueries
{
    public static Expression<Func<Usuario, bool>> BuscarPorId(Guid id)
    {
        return x => x.Id == id;
    }

    public static Expression<Func<Usuario, bool>> BuscarPorNomeESenha(string nome, string senha)
    {
        return x => x.Nome == nome && x.Senha == senha;
    }
    
    public static Expression<Func<Usuario, bool>> BuscarPorNome(string nome)
    {
        return x => x.Nome == nome;
    }
} 