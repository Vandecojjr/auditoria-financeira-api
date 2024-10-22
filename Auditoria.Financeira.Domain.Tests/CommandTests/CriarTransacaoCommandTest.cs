using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Enum;

namespace Auditoria.Financeira.Domain.Tests.CommandTests;

[TestClass]
public class CriarTransacaoCommandTest
{
    private readonly CriarTransacaoCommand _comandoInvalido = new(-1,TipoDaTransacao.Compra,Guid.NewGuid());
    private readonly CriarTransacaoCommand _cmandoValido = new(1,TipoDaTransacao.Compra, Guid.NewGuid());
    
    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        var comando = _comandoInvalido;
        var resultado = comando.Validar();
        Assert.IsFalse(resultado.IsValid);
    }
    
    [TestMethod]
    public void Dado_um_comando_valido()
    {
        var comando = _cmandoValido;
        var resultado = comando.Validar();
        Assert.IsTrue(resultado.IsValid);
    }
}