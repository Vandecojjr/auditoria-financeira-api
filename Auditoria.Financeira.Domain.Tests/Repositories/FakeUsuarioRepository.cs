using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Repositories;

namespace Auditoria.Financeira.Domain.Tests.Repositories;

public class FakeUsuarioRepository : IUsuarioRepository
{
    public Usuario BuscarPorId(Guid id)
    {
        return new Usuario("Nome", "SenhaSenha", 0);
    }

    public void Criar(Usuario usuario)
    {
    }

    public void Atualizar(Usuario usuario)
    {
    }
}