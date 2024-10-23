using Auditoria.Financeira.Domain.Entities;

namespace Auditoria.Financeira.Domain.Repositories;

public interface IUsuarioRepository
{
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorNomeESenha(string nome, string senha);
    Usuario BuscarPorNome(string nome);
     void Criar(Usuario usuario); 
     void Atualizar(Usuario usuario);
}
