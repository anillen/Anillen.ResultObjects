namespace Anillen.ResultObjects;

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        if ((IsSuccess && error != Error.None) || (!IsSuccess && Error == Error.None))
            throw new ArgumentException("Invalid arguments provided");

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success()
    {
        return new Result(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }
}