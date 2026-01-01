using FluentResults;
using MediatR;
using SmartRoster.Application.Abstractions.Services;
using SmartRoster.Domain.Entities;

namespace SmartRoster.Application.Employees.Commands.CreateEmployee;

public sealed class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Result<Employee>>
{
    private readonly IEmployeeService _service;

    public CreateEmployeeHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<Result<Employee>> Handle(CreateEmployeeCommand request, CancellationToken ct)
    {
        var employee = new Employee(request.FirstName, request.LastName, request.Email, request.Mobile, request.Department, request.EmployementType);
        return await _service.CreateAysnc(employee, ct);
    }
}
