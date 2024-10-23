using Auditoria.Financeira.Domain.Entities;

namespace Auditoria.Financeira.Domain.Api.Service.Cointratos;

public interface ITransacaoExportarService
{
    byte[] ExportarCsv(IEnumerable<Transacao> transacoes);
    byte[] ExportarXlsx(IEnumerable<Transacao> transacoes);
}