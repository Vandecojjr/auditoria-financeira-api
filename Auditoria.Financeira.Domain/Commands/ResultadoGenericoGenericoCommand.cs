using Auditoria.Financeira.Domain.Commands.Contratos;

namespace Auditoria.Financeira.Domain.Commands;

public class ResultadoGenericoGenericoCommand : IResultadoGenericoCommand
{
    public ResultadoGenericoGenericoCommand()
    {
    }

    public ResultadoGenericoGenericoCommand(bool sucesso, string mensagem, object dados)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Dados = dados;
    }

    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Dados { get; set; }
}