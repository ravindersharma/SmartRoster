
namespace  SmartRoster.Domain.Entities.Base;
/// <summary>
/// Represents the base entity with audit information.
/// </summary>
public abstract class BaseEntity
{
    #region  Properties
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; protected set; }

    #endregion

    #region Methods

    public void MarkUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    #endregion
}