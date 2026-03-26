namespace WorkShiftScheduler.Application.Exceptions;

public class ValidationException : Exception
{
    public IReadOnlyCollection<string> Keys { get; }

    public ValidationException(IEnumerable<string> keys)
        : base("Validation error")
    {
        Keys = keys.ToList().AsReadOnly();
    }
}
