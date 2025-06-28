using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garciss.ROP.ApiExtensions;

public static class ResultApiExtensions
{
    public static ProblemDetails ToProblemDetails(this Result result)
    {
        ProblemDetails problems = new()
        {
            Title = "Error(s) found",
            Detail = "One or more errors occurred",
        };

        problems.Extensions.Add("ValidationErrors", result.Errors);

        return problems;
    }

    public static IResult ToResults(this Result result)
    {
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.ToProblemDetails());
    }

    public static IActionResult ToActionResult(this Result result)
    {
        return result.IsSuccess
            ? new ObjectResult(null)
            : new BadRequestObjectResult(result.ToProblemDetails());
    }
}
