using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Infra.Context;
using Auditoria.Financeira.Domain.Queries;
using Auditoria.Financeira.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auditoria.Financeira.Domain.Infra.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly DataContext _context;

    public TransacaoRepository(DataContext context)
    {
        _context = context;
    }
    public void Criar(Transacao usuario)
    {
        _context.Add(usuario);
        _context.SaveChanges();
    }

    public void Deletar(Transacao usuario)
    {
        _context.Remove(usuario);
        _context.SaveChanges();
    }

    public Transacao BuscarPorId(Guid id)
    {
        return _context.Transacoes.FirstOrDefault(TransacoeQueries.BuscarPorId(id));
    }

    public IEnumerable<Transacao> BuscarTodas(Guid id, int skip = 1, int take = 10)
    {
        return _context.Transacoes.AsNoTracking().Where(TransacoeQueries.BucarTodas(id)).Skip(skip).Take(take);
    }

    public IEnumerable<Transacao> BuscarPorPeriodo(DateTime dataicial, DateTime dataFinal, Guid id, int skip = 1, int take = 10)
    {
        return _context.Transacoes.AsNoTracking().Where(TransacoeQueries.BuscarPorPeriodo(dataicial, dataFinal, id)).Skip(skip).Take(take);
    }

    public IEnumerable<Transacao> BuscarPorTipo(TipoDaTransacao tipo, Guid id, int skip = 1, int take = 10)
    {
        return _context.Transacoes.AsNoTracking().Where(TransacoeQueries.BuscarPorTipo(tipo, id)).Skip(skip).Take(take);
    }
}