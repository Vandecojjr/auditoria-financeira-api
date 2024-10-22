using Auditoria.Financeira.Domain.Entities;
using Auditoria.Financeira.Domain.Infra.Context;
using Auditoria.Financeira.Domain.Queries;
using Auditoria.Financeira.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auditoria.Financeira.Domain.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;
    
    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }
    
    public Usuario BuscarPorId(Guid id)
    {
        return _context.Usuarios.FirstOrDefault(UsuarioQueries.BuscarPorId(id));
    }

    public void Criar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Atualizar(Usuario usuario)
    {
        _context.Entry(usuario).State = EntityState.Modified;
        _context.SaveChanges();
    }
}