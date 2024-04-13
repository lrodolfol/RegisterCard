namespace RegisterCard.Core.Entities;
public abstract class Entity : IEquatable<Guid>
{
    public Guid Id { get; private set; }

    public Entity()
        => Id = Guid.NewGuid();
    public bool Equals(Guid other) =>
        Id == other;
    public override int GetHashCode() =>
        Id.GetHashCode();
}

