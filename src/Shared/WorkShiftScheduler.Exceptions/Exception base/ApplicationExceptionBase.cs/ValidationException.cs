
namespace ExceptionBase.cs;

public class ValidationException : Exception
{
    public IReadOnlyCollection<string> Keys { get;}

    public ValidationException(IEnumerable<string> keys)
        : base("Validation error")
    {
       keys = keys.ToList().AsReadOnly();
    }


}
