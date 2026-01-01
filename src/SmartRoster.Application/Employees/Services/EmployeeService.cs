using FluentResults;
using SmartRoster.Application.Abstractions.Repositories;
using SmartRoster.Application.Abstractions.Services;
using SmartRoster.Application.Abstractions.UnitOfWork;
using SmartRoster.Domain.Entities;

namespace SmartRoster.Application.Employees.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _repo;
    private readonly IUnitOfWork _uow;

    public EmployeeService(IRepository<Employee> repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<Result<Employee>> CreateAysnc(Employee employee, CancellationToken ct)
    {
        await _repo.AddAsync(employee,ct);
        await _uow.SaveChangesAsync();

        return Result.Ok(employee);
    }
}
