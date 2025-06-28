using System.Collections.Immutable;

namespace Garciss.ROP;

public readonly struct Result
{
    public ImmutableArray<Error> Errors { get; }
    public bool IsSuccess => Errors.IsDefaultOrEmpty;

    public Result()
    {
        Errors = [];
    }

    public Result(ImmutableArray<Error> errors)
    {
        if (errors.IsDefaultOrEmpty)
        {
            throw new ArgumentException("errors can't be empty");
        }

        Errors = errors;
    }

    public static Result Success() => new();

    public static Result Failure(Error error) => new([error]);

    public static Result Failure(ImmutableArray<Error> errors) => new(errors);
}
