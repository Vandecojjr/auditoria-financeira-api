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
    public void Criar(Transacao transacao)
    {
        _context.Transacoes.Add(transacao);
        _context.SaveChanges();
    }

    public void Deletar(Transacao transacao)
    {
        _context.Remove(transacao);
        _context.SaveChanges();
    }

    public Transacao BuscarPorId(Guid id)
    {
        try
        {
            return _context.Transacoes.FirstOrDefault(TransacoeQueries.BuscarPorId(id));
        }
        catch (Exception e)
        {
            throw new Exception(message:"Erro ao buscar transação");
        }
        
    }

    public IEnumerable<Transacao> BuscarTodas(Guid id, int skip = 0, int take = 20)
    {
        try
        {
            return _context.Transacoes.AsNoTracking().Where(TransacoeQueries.BucarTodas(id)).
                OrderBy(x => x.Data).Skip(skip).Take(take);
        }
        catch (Exception e)
        {
            throw new Exception(message:"Erro ao buscar transações");
        }
        
    }

    public IEnumerable<Transacao> BuscarPorPeriodo(DateTime dataicial, DateTime dataFinal, Guid id, int skip = 0, int take = 20)
    {
        try
        {
            return _context.Transacoes.AsNoTracking().Where(TransacoeQueries.BuscarPorPeriodo(dataicial, dataFinal, id)).
                OrderBy(x => x.Data).Skip(skip).Take(take);
        }
        catch (Exception e)
        {
            throw new Exception(message:"Erro ao buscar transações");
        }
    }

    public IEnumerable<Transacao> BuscarPorTipo(TipoDaTransacao tipo, Guid id, int skip = 0, int take = 20)
    {
        try
        {
            return _context.Transacoes.AsNoTracking().Where(TransacoeQueries.BuscarPorTipo(tipo, id)).
                OrderBy(x => x.Data).Skip(skip).Take(take);
        }
        catch (Exception e)
        {
            throw new Exception(message:"Erro ao buscar transações");
        }
        
    }
}