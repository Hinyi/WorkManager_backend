namespace Shared.Options;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Errors = new[] { error };
    }

    protected internal Result(bool isSuccess, Error[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }
    
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error[] Errors { get; }
    
}