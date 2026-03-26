using System.Globalization;
using WorkShiftScheduler.Application.Exceptions;

namespace WorkShiftScheduler.Shared.Exceptions;

public sealed class RequestValidationException : ApplicationExceptionBase
{
    public IReadOnlyCollection<string> Errors { get; }

    public RequestValidationException(IEnumerable<string> errors)
        : base("VALIDATION_ERROR")
    {
        Errors = errors.ToList();
    }
}
