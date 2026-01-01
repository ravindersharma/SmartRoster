using FluentResults;
using MediatR;
using SmartRoster.Domain.Entities;
using SmartRoster.Domain.Enums;

namespace SmartRoster.Application.Employees.Commands.CreateEmployee;

public sealed record CreateEmployeeCommand(string FirstName, string LastName, string Email, string Mobile, string Department, EmploymentType EmployementType) : IRequest<Result<Employee>>;
