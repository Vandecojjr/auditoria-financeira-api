namespace Auditoria.Financeira.Domain.Validations.Mensagens;

public class UsuarioErrorMessages
{
    public static string NomeVazio = "O nome do usuário não pode ser vazio.";
    public static string NomeComTamanhoInvalido = "O nome do usuário deve ter entre 3 e 50 caracteres.";
    
    public static string SenhaVazia = "A senha do usuário não pode ser vazia.";
    public static string SenhaComTamanhoInvalido = "A senha do usuário deve ter entre 6 e 32 caracteres.";
    public static string SaldoEmContaInvalido = "O saldo do usuário não pode ser negativo.";
}