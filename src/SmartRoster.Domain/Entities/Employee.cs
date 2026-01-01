using System.Data.SqlTypes;
using SmartRoster.Domain.Entities.Base;
using SmartRoster.Domain.Enums;
namespace SmartRoster.Domain.Entities;
/// <summary>
/// Represents an employee in the roster system.
/// </summary>
/// 
public class Employee : BaseEntity
{

    #region Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Employee() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public Employee(string firstName, string lastName, string email, string mobile, string department, EmploymentType employmentType)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Mobile = mobile;
        Department = department;
        EmploymentType = employmentType;
        Status = EmployeeStatus.Active;
    }

    #endregion

    #region Properties

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Mobile { get; private set; }
    public string Department { get; private set; }
    public EmploymentType EmploymentType { get; private set; }
    public EmployeeStatus Status { get; private set; }

    #endregion

    #region  Behavior
    public void Activate() => Status = EmployeeStatus.Active;

    public void DeActivate() => Status = EmployeeStatus.InActive;

    #endregion
}