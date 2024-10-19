namespace Auditoria.Financeira.Domain.Entities;

public abstract class Entidade : IEquatable<Entidade>
{
     public Entidade()
     {
          Id = Guid.NewGuid();
     }

     public Guid Id { get; private set; }


     public bool Equals(Entidade? other)
     {
          return Id == other?.Id;
     }
}