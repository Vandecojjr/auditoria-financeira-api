using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Repositories;

namespace Auditoria.Financeira.Domain.Tests.Repositories;

public class FakeTransacaoRepository : ITransacaoRepository
{
    public void Criar(Transacao usuario)
    {
    }

    public void Deletar(Transacao usuario)
    {
    }

    public Transacao BuscarPorId(Guid id)
    {
        return new Transacao(1, TipoDaTransacao.Compra);
    }

    public IEnumerable<Transacao> BuscarTodas(Guid id, int skip = 1, int take = 10)
    {
        return new List<Transacao>()
        {
            new Transacao(1, TipoDaTransacao.Compra),
            new Transacao(1, TipoDaTransacao.Deposito),
        };
    }

    public IEnumerable<Transacao> BuscarPorPeriodo(DateTime dataicial, DateTime dataFinal, Guid id, int skip = 1, int take = 10)
    {
        return new List<Transacao>()
        {
            new Transacao(1, TipoDaTransacao.Compra),
            new Transacao(1, TipoDaTransacao.Deposito),
        };
    }

    public IEnumerable<Transacao> BuscarPorTipo(TipoDaTransacao tipo, Guid id, int skip = 1, int take = 10)
    {
        return new List<Transacao>()
        {
            new Transacao(1, TipoDaTransacao.Compra),
            new Transacao(1, TipoDaTransacao.Deposito),
        };
    }
}