using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRoster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRoster.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF configuration for Employee entity.
/// </summary>
public class EmployeConfig : BaseEntityConfig<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Mobile).IsRequired().HasMaxLength(15);
        builder.Property(p => p.Department).IsRequired().HasMaxLength(100);


        builder.HasIndex(p => p.Email).IsUnique();
    }
}
