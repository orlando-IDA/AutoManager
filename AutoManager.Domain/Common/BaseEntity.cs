namespace AutoManager.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; protected set; } 

    public bool Active { get; protected set; } = true;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}