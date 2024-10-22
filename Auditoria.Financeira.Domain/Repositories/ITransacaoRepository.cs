using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;

namespace Auditoria.Financeira.Domain.Repositories;

public interface ITransacaoRepository
{
    public void Criar(Transacao usuario); 
    public void Deletar(Transacao usuario);
    
    public Transacao BuscarPorId(Guid id);
    public IEnumerable<Transacao> BuscarTodas(Guid id, int skip = 1, int take = 10);
    public IEnumerable<Transacao> BuscarPorPeriodo(DateTime dataicial, DateTime dataFinal, Guid id, int skip = 1, int take = 10);
    public IEnumerable<Transacao> BuscarPorTipo(TipoDaTransacao tipo, Guid id, int skip = 1, int take = 10);
}
