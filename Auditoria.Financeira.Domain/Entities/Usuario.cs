using System;

namespace Auditoria.Financeira.Domain.Entities;

public class Usuario : Entity
{
    public Usuario(string nome, string senha, decimal saldoEmConta)
    {
        Nome = nome;
        Senha = senha;
        SaldoEmConta = 0;
    }

    public string Nome { get; private set; }
    public string Senha { get; private set; }
    public decimal SaldoEmConta { get; private set; }
}