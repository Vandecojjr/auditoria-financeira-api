using Auditoria.Financeira.Domain.Commands.Contratos;
using Auditoria.Financeira.Domain.Validations;

namespace Auditoria.Financeira.Domain.Commands;

public class CriarUsuarioCommand : ICommand
{
    public CriarUsuarioCommand()
    {
    }

    public CriarUsuarioCommand(string nome, string senha, decimal saldoEmConta)
    {
        Nome = nome;
        Senha = senha;
        SaldoEmConta = saldoEmConta;
    }

    public string Nome { get; set; }
    public string Senha { get; set; }
    public decimal  SaldoEmConta { get; set; }

    public bool Validar()
    {
        return new CriarUsuarioCommandValidator().Validate(this).IsValid;
    }
}