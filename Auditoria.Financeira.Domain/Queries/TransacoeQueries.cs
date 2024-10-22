using System.Linq.Expressions;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;

namespace Auditoria.Financeira.Domain.Queries;

public static class TransacoeQueries
{
    public static Expression<Func<Transacao, bool>> BuscarPorId(Guid id)
    {
        return x => x.Id == id;
    }

    public static Expression<Func<Transacao, bool>> BucarTodas(Guid id)
    {
        return x => x.UsuarioId == id;
    }

    public static Expression<Func<Transacao, bool>> BuscarPorTipo(TipoDaTransacao tipo, Guid id)
    {
        return x => x.Tipo == tipo && x.UsuarioId == id;
    }
    
    public static Expression<Func<Transacao, bool>> BuscarPorPeriodo(DateTime dataInicial, DateTime dataFinal, Guid id)
    {
        return x => x.Data.Date >= dataInicial.Date && x.Data.Date <= dataFinal.Date && x.UsuarioId == id;
    }
}