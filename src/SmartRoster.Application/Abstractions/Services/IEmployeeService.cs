using FluentResults;
using SmartRoster.Domain.Entities;

namespace SmartRoster.Application.Abstractions.Services
{
    public interface IEmployeeService
    {
        Task<Result<Employee>> CreateAysnc(Employee employee, CancellationToken ct = default);
    }
}
