using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SmartRoster.Application.Abstractions.Services;
using SmartRoster.Application.Employees.Services;

namespace SmartRoster.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);


        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    
    }
}
