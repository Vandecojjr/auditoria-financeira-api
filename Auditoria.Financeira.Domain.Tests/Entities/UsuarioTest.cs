using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;

namespace Auditoria.Financeira.Domain.Tests.Entities;

[TestClass]
public class UsuarioTest
{
    private Usuario _usuario = new("Nome", "SenhaSenha", 0);
    [TestMethod]
    public void Dado_um_deposito_o_saldo_deve_ser_acrescentado()
    {
        var valorAntigo = _usuario.SaldoEmConta;
        _usuario.AlterarSaldo(TipoDaTransacao.Deposito, 10);
        Assert.IsTrue(valorAntigo < _usuario.SaldoEmConta);
    }
    
    [TestMethod]
    public void Dado_um_saque_o_saldo_deve_ser_diminuido()
    {
        var valorAntigo = _usuario.SaldoEmConta;
        _usuario.AlterarSaldo(TipoDaTransacao.Saque, 10);
        Assert.IsTrue(valorAntigo > _usuario.SaldoEmConta);
    }
    
    [TestMethod]
    public void Dado_uma_compra_o_saldo_deve_ser_diminuido()
    {
        var valorAntigo = _usuario.SaldoEmConta;
        _usuario.AlterarSaldo(TipoDaTransacao.Compra, 10);
        Assert.IsTrue(valorAntigo > _usuario.SaldoEmConta);
    }
}