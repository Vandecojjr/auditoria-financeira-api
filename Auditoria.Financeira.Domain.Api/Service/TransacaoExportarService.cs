using System.Globalization;
using System.Text;
using Auditoria.Financeira.Domain.Api.Service.Cointratos;
using Auditoria.Financeira.Domain.Entities;
using CsvHelper;
using OfficeOpenXml;

namespace Auditoria.Financeira.Domain.Api.Service;

public class TransacaoExportarService : ITransacaoExportarService
{
    public byte[] ExportarCsv(IEnumerable<Transacao> transacoes)
    {
        using var memoryStream = new MemoryStream();
        using (var writer = new StreamWriter(memoryStream, new UTF8Encoding(false)))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(transacoes);
        }
        return memoryStream.ToArray();
    }

    public byte[] ExportarXlsx(IEnumerable<Transacao> transacoes)
    {
        var listaTransacoes = transacoes.ToList();

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Transações");

        worksheet.Cells[1, 1].Value = "Id";
        worksheet.Cells[1, 2].Value = "Tipo";
        worksheet.Cells[1, 3].Value = "Valor";
        worksheet.Cells[1, 4].Value = "Data";

        for (int i = 0; i < listaTransacoes.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = listaTransacoes[i].Id;
            worksheet.Cells[i + 2, 2].Value = listaTransacoes[i].Tipo;
            worksheet.Cells[i + 2, 3].Value = listaTransacoes[i].Valor;
        
            var data = listaTransacoes[i].Data;

            worksheet.Cells[i + 2, 4].Value = data;
            worksheet.Cells[i + 2, 4].Style.Numberformat.Format = "dd/MM/yyyy";
        }

        var fileStream = new MemoryStream();
        package.SaveAs(fileStream);
        return fileStream.ToArray();
    }

}