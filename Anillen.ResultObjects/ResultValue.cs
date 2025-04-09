namespace Anillen.ResultObjects;

public class ResultValue<T>
{
    private readonly T? _value;

    private ResultValue(bool isSuccess, Error error, T? value)
    {
        if ((IsSuccess && error != Error.None) || (!IsSuccess && Error == Error.None))
            throw new ArgumentException("Invalid arguments provided");

        IsSuccess = isSuccess;
        Error = error;
        _value = value;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public T Value
    {
        get
        {
            if (IsFailure)
                throw new Exception(Error.Description);
            return _value!;
        }
    }

    public static ResultValue<T> Success(T value)
    {
        return new ResultValue<T>(true, Error.None, value);
    }

    public static ResultValue<T> Failure(Error error)
    {
        return new ResultValue<T>(false, error, default);
    }
}