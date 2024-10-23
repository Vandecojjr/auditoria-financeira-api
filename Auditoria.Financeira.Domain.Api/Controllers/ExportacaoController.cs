using System.Security.Claims;
using Auditoria.Financeira.Domain.Api.Service.Cointratos;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auditoria.Financeira.Domain.Api.Controllers;

[Authorize]
[ApiController]
[Route("v1/exportacao")]
public class ExportacaoController : ControllerBase
{
    private readonly ITransacaoExportarService _transacaoExportService;
    private readonly ITransacaoRepository _transacaoRepository;

    public ExportacaoController(ITransacaoExportarService transacaoExportService, ITransacaoRepository transacaoRepository)
    {
        _transacaoExportService = transacaoExportService;
        _transacaoRepository = transacaoRepository;
    }

    [HttpGet("exportar-csv")]
    public IActionResult ExportarCsv([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        var transacoes = _transacaoRepository.BuscarTodas(Guid.Parse(usuarioId), skip, take);
        var csvBytes = _transacaoExportService.ExportarCsv(transacoes);
        return File(csvBytes, "text/csv", "transacoes.csv");
    }

    [HttpPost("exportar-xlsx")]
    public IActionResult ExportarXlsx([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var usuarioId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        var transacoes = _transacaoRepository.BuscarTodas(Guid.Parse(usuarioId), skip, take);
        var xlsxBytes = _transacaoExportService.ExportarXlsx(transacoes);
        return File(xlsxBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "transacoes.xlsx");
    }
}