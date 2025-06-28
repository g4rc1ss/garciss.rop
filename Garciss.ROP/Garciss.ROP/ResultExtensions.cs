using System.Collections.Immutable;

namespace Garciss.ROP;

public static class ResultExtensions
{
    public static Result<T> ToResult<T>(this T value) => new(value);

    public static Result<T> ToResult<T>(this Error error) => new([error]);

    public static Result<T> ToResult<T>(this ImmutableArray<Error> errors) => new(errors);

    public static Result ToResult(this Error error) => new([error]);

    public static Result ToResult(this ImmutableArray<Error> errors) => new(errors);
}
