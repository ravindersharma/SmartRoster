using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRoster.Domain.Entities.Base;

namespace SmartRoster.Infrastructure.Persistence.Configurations;

/// <summary>
/// Global configuration for all entities inheriting BaseEntity.
/// </summary>
public abstract class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
    }
}
