using System.Globalization;
using System.Resources;

namespace WorkShiftScheduler.Application.Exceptions;

public abstract class ApplicationExceptionBase : Exception
{
    protected ApplicationExceptionBase(string key)
        : base(GetMessage(key))
    {
        Key = key;
    }

    public string Key { get; }

    protected static string GetMessage(string key)
    {
        var rm = new ResourceManager(
            "WorkShiftScheduler.Application.Resources.ResourceMessages",
            typeof(ApplicationExceptionBase).Assembly);

        return rm.GetString(key, CultureInfo.CurrentUICulture)
               ?? key;
    }
}
