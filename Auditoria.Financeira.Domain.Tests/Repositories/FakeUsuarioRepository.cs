using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Repositories;

namespace Auditoria.Financeira.Domain.Tests.Repositories;

public class FakeUsuarioRepository : IUsuarioRepository
{
    public Usuario BuscarPorId(Guid id)
    {
        return new Usuario("Nome", "SenhaSenha", 0);
    }

    public Usuario BuscarPorNomeESenha(string nome, string senha)
    {
        return new Usuario("Nome", "SenhaSenha", 0);
    }

    public Usuario BuscarPorNome(string nome)
    {
        var usuario = new Usuario("Nome", "SenhaSenha", 0);
        if (nome == usuario.Nome)
        {
            return usuario;
        }

        return null;
    }

    public void Criar(Usuario usuario)
    {
    }

    public void Atualizar(Usuario usuario)
    {
    }
}