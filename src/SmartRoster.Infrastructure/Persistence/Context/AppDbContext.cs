using Microsoft.EntityFrameworkCore;
using SmartRoster.Domain.Entities;

namespace SmartRoster.Infrastructure.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //Global Soft-Delete Filter
            

            base.OnModelCreating(builder);
        }
    }
}
