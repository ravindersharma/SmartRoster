using FluentValidation;

namespace SmartRoster.Application.Employees.Commands.CreateEmployee;

public sealed class CreateEmployeeValidator:AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x=>x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x=>x.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(x=>x.Mobile).NotEmpty().MaximumLength(15);
        RuleFor(x=>x.Department).NotEmpty().MaximumLength(100);
    }
}
