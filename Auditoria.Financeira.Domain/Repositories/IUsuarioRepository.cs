using Auditoria.Financeira.Domain.Entities;

namespace Auditoria.Financeira.Domain.Repositories;

public interface IUsuarioRepository
{
    Usuario BuscarPorId(Guid id);
     void Criar(Usuario usuario); 
     void Atualizar(Usuario usuario);
}
