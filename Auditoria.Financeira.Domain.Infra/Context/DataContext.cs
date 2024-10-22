using Auditoria.Financeira.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auditoria.Financeira.Domain.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transacao>().Property(x => x.Id);
        modelBuilder.Entity<Transacao>().Property(x => x.Valor).HasPrecision(18, 2).IsRequired();
        modelBuilder.Entity<Transacao>().Property(x => x.Data);
        modelBuilder.Entity<Transacao>().Property(x => x.Tipo).IsRequired();
        modelBuilder.Entity<Transacao>().Property(x => x.UsuarioId).IsRequired();
        
        modelBuilder.Entity<Usuario>().Property(x => x.Id);
        modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(x => x.SaldoEmConta).HasPrecision(18, 2).IsRequired();
    }
}