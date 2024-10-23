using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Repositories;

namespace Auditoria.Financeira.Domain.Tests.Repositories;

public class FakeTransacaoRepository : ITransacaoRepository
{
    public void Criar(Transacao transacao)
    {
    }

    public void Deletar(Transacao transacao)
    {
    }

    public Transacao BuscarPorId(Guid id)
    {
        return new Transacao(1, TipoDaTransacao.Compra, Guid.NewGuid());
    }

    public IEnumerable<Transacao> BuscarTodas(Guid id, int skip = 1, int take = 10)
    {
        return new List<Transacao>()
        {
            new Transacao(1, TipoDaTransacao.Compra,Guid.NewGuid()),
            new Transacao(1, TipoDaTransacao.Deposito,Guid.NewGuid()),
        };
    }

    public IEnumerable<Transacao> BuscarPorPeriodo(DateTime dataicial, DateTime dataFinal, Guid id, int skip = 0, int take = 20)
    {
        return new List<Transacao>()
        {
            new Transacao(1, TipoDaTransacao.Compra,Guid.NewGuid()),
            new Transacao(1, TipoDaTransacao.Deposito,Guid.NewGuid()),
        };
    }

    public IEnumerable<Transacao> BuscarPorTipo(TipoDaTransacao tipo, Guid id, int skip = 0, int take = 20)
    {
        return new List<Transacao>()
        {
            new Transacao(1, TipoDaTransacao.Compra,Guid.NewGuid()),
            new Transacao(1, TipoDaTransacao.Deposito,Guid.NewGuid()),
        };
    }
}