using Auditoria.Financeira.Domain.Entities;

namespace Auditoria.Financeira.Domain.Repositories;

public interface ITransacaoRepository
{
    public void Criar(Transacao usuario); 
    public void Deletar(Transacao usuario);
}
