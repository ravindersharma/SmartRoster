
namespace  SmartRoster.Domain.Entities.Base;
/// <summary>
/// Base entity including auditing and soft-delete support.
/// </summary>
public abstract class BaseEntity
{
    #region  Properties
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public string? CreatedBy { get;protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public string? UpdatedBy { get; protected set; }
    public bool IsDeleted { get; protected set; }
    public DateTime? DeletedAt { get;protected set; }
    public string?  DeletedBy { get;protected set; }

    #endregion

    #region Methods

    public void MarkCreated(string? user) {
        CreatedBy = user;
    }
    public void MarkUpdated(string? user)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = user;
    }

    public void SoftDelete(string? user) { 
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = user; }

    #endregion
}