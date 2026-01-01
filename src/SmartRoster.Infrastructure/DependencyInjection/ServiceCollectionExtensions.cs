using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartRoster.Application.Abstractions.Repositories;
using SmartRoster.Application.Abstractions.UnitOfWork;
using SmartRoster.Infrastructure.Persistence.Context;
using SmartRoster.Infrastructure.Persistence.Interceptors;
using SmartRoster.Infrastructure.Persistence.Uow;
using SmartRoster.Infrastructure.Repositories;
using SmartRoster.Shared;

namespace SmartRoster.Infrastructure.DependencyInjection;


/// <summary>
/// Registers infrastructure services.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string sqlContionString) {
        
        // regsiter Interceptor
        services.AddSingleton(new AuditInterceptor(AppContansts.SystemUser));

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            var interceptor = sp.GetRequiredService<AuditInterceptor>();

            options.UseSqlite(sqlContionString);
            options.AddInterceptors(interceptor);
        });

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;

    }
}
