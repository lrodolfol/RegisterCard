namespace RegisterCard.Core.Entities;
public abstract class Entity : IEquatable<int>
{
    public int Id { get; private set; }

    //public Entity()
    //    => Id = Guid.NewGuid();
    public bool Equals(int other) =>
        Id == other;
    public override int GetHashCode() =>
        Id.GetHashCode();
}

