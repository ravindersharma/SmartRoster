using MediatR;
using SmartRoster.Application.Employees.Commands.CreateEmployee;

namespace SmartRoster.Api.Endpoints.Employees;

public static class CreateEmployeeEndpoint
{
    public static IEndpointRouteBuilder MapCreateEmployee(this IEndpointRouteBuilder app) {

        app.MapPost("/api/employess", async (CreateEmployeeCommand cmd, IMediator mediator, CancellationToken ct) =>
        {
            var result= await mediator.Send(cmd,ct);

            return result.IsSuccess?Results.Created($"/api/employees/{result.Value.Id}",result.Value)
            : Results.BadRequest(result.Errors);
        });

        return app;
    
    }
}
