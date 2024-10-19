namespace Auditoria.Financeira.Domain.Entities;

public class Usuario : Entidade
{
    public Usuario(string nome, string senha,Guid contaId)
    {
        Nome = nome;
        Senha = senha;
        SaldoEmConta = 0;
    }

    public string Nome { get; private set; }
    public string Senha { get; private set; }
    public decimal SaldoEmConta { get; private set; }
}