namespace WorkShiftScheduler.Application.Exceptions;

public class RequestValidationException : Exception
{
    public IReadOnlyCollection<string> Errors { get; }

    public RequestValidationException(IEnumerable<string> errors)
        : base("Validation error")
    {
        Errors = errors.ToList().AsReadOnly();
    }
}
