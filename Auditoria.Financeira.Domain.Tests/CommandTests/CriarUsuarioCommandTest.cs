using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Enum;

namespace Auditoria.Financeira.Domain.Tests.CommandTests;

[TestClass]
public class CriarUsuarioCommandTest
{
    private readonly CriarUsuarioCommand _comandoInvalido = new("", "", -1);
    private readonly CriarUsuarioCommand _comandoValido = new("Nome", "SenhaSenha", 0);
    
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
        var comando =_comandoValido;
        var resultado = comando.Validar();
        Assert.IsTrue(resultado.IsValid);
    }
}