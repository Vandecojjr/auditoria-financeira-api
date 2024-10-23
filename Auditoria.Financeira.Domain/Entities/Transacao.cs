using System;
using Auditoria.Financeira.Domain.Enum;

namespace Auditoria.Financeira.Domain.Entities;

public class Transacao : Entity
{
    public Transacao(decimal valor, TipoDaTransacao tipo, Guid usuarioId)
    {
        Valor = valor;
        Tipo = tipo;
        Data = DateTime.Now;
        UsuarioId = usuarioId;
    }

    public decimal Valor { get; private set; }
    public TipoDaTransacao Tipo { get; private set; }
    public DateTime Data { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario  { get; private set; }
}