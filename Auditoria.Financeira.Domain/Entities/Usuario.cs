using System;
using System.Text.Json.Serialization;
using Auditoria.Financeira.Domain.Enum;

namespace Auditoria.Financeira.Domain.Entities;

public class Usuario : Entity
{
    public Usuario(string nome, string senha, decimal saldoEmConta)
    {
        Nome = nome;
        Senha = senha;
        SaldoEmConta = saldoEmConta;
    }

    public string Nome { get; private set; }
    [JsonIgnore]
    public string Senha { get; private set; }
    public decimal SaldoEmConta { get; private set; }
    public ICollection<Transacao> Transacoes { get; set; }
    
    
    
    public void AlterarSaldo(TipoDaTransacao tipo, decimal valor)
    {
        var operacoes = new Dictionary<TipoDaTransacao, Action<decimal>>
        {
            { TipoDaTransacao.Deposito, Depositar },
            { TipoDaTransacao.Compra, Comprar },
            { TipoDaTransacao.Saque, Sacar }
        };
        
        
        operacoes[tipo](valor);
    }
    
    private void Depositar(decimal valor)
    {
        this.SaldoEmConta += valor;
    }
    
    private void Sacar(decimal valor)
    {
        this.SaldoEmConta -= valor;
    }
    
    private void Comprar(decimal valor)
    {
        this.SaldoEmConta -= valor;
    }
}