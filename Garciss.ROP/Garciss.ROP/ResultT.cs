using System.Collections.Immutable;

namespace Garciss.ROP;

public readonly struct Result<T>
{
    public T? Value { get; }
    public ImmutableArray<Error> Errors { get; }

    public bool IsSuccess => Errors.IsDefaultOrEmpty;

    public Result(T value)
    {
        Value = value;
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

    public static implicit operator Result<T>(T value) => new(value);

    public static implicit operator Result<T>(Error error) => new([error]);

    public static implicit operator Result<T>(ImmutableArray<Error> errors) => new(errors);
}
