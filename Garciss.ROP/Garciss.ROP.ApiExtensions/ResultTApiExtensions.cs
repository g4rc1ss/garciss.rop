using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garciss.ROP.ApiExtensions;

public static class ResultTApiExtensions
{
    public static ProblemDetails ToProblemDetails<T>(this Result<T> result)
    {
        ProblemDetails problems = new()
        {
            Title = "Error(s) found",
            Status = StatusCodes.Status400BadRequest,
            Detail = "One or more errors occurred",
        };

        problems.Extensions.Add("ValidationErrors", result.Errors);

        return problems;
    }

    public static IResult ToResults<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.Problem(result.ToProblemDetails());
    }

    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? new ObjectResult(result.Value)
            : new BadRequestObjectResult(result.ToProblemDetails());
    }
}
