using System.Text.Json.Serialization;

namespace DUPSS.Domain.Abstractions.Shared;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new InvalidOperationException();
        IsSuccess = isSuccess;
        Error = error;
    }

    public Error Error { get; }

    public bool IsSuccess { get; }

    public static Result Success() => new Result(true, Error.None);

    public static Result<T> Success<T>(T value) => new Result<T>(value, true, Error.None);

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<T> Failure<T>(Error error) => new Result<T>(default!, false, error);

    public static Result<T> Create<T>(T? value) =>
        value is null ? Failure<T>(Error.NullValue) : Success(value);
}

public class Result<T> : Result
{
    private readonly T? _value;

    internal Result(T value, bool isSuccess, Error error)
        : base(isSuccess, error) => _value = value;

    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Value => _value;

    public static implicit operator Result<T>(T value) => Create(value);
}
