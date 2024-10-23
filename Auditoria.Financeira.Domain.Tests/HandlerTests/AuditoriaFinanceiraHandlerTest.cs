using Auditoria.Financeira.Domain.Commands;
using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Enum;
using Auditoria.Financeira.Domain.Handlers;
using Auditoria.Financeira.Domain.Tests.Repositories;

namespace Auditoria.Financeira.Domain.Tests.HandlerTests;

[TestClass]
public class AuditoriaFinanceiraHandlerTest
{
    private readonly CriarTransacaoCommand _criarTransacaoComandoInvalido = new(-1,TipoDaTransacao.Compra,Guid.NewGuid());
    private readonly CriarTransacaoCommand _criarTransacaoComandoValido = new(1,TipoDaTransacao.Compra,Guid.NewGuid());
    private readonly CriarUsuarioCommand _criarUsuarioComandoInvalido = new("UmNome","",0);
    private readonly CriarUsuarioCommand _criarUsuarioComandoValido = new("Outro","SenhaSenha",0);
    private readonly CriarUsuarioCommand _criarUsuarioJaExistente = new("Nome","SenhaSenha",0);
    private readonly AuditoriaFinanceiraHandler _handler = new(new FakeUsuarioRepository(), new FakeTransacaoRepository());
    
    [TestMethod]
    public void Dado_um_criar_transacao_command_invalido()
    {
        var resultado = (ResultadoGenericoGenericoCommand)_handler.Handle(_criarTransacaoComandoInvalido);
        Assert.AreEqual(resultado.Sucesso, false);
    }

    [TestMethod]
    public void Dado_um_criar_transacao_command_valido()
    {
        var resultado = (ResultadoGenericoGenericoCommand)_handler.Handle(_criarTransacaoComandoValido);
        Assert.AreEqual(resultado.Sucesso, true);
    }
    
    [TestMethod]
    public void Dado_um_criar_usuario_command_invalido()
    {
        var resultado = (ResultadoGenericoGenericoCommand)_handler.Handle(_criarUsuarioComandoInvalido);
        Assert.AreEqual(resultado.Sucesso, false);
    }
    
    [TestMethod]
    public void Dado_um_criar_usuario_command_valido()
    {
        var resultado = (ResultadoGenericoGenericoCommand)_handler.Handle(_criarUsuarioComandoValido);
        Assert.AreEqual(resultado.Sucesso, true);
    }
    
    [TestMethod]
    public void Dado_um_criar_usuario_com_usuario_ja_existente()
    {
        var resultado = (ResultadoGenericoGenericoCommand)_handler.Handle(_criarUsuarioJaExistente);
        Assert.AreEqual(resultado.Sucesso, false);
    }
}