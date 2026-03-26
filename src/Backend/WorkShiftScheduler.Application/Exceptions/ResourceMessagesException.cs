namespace WorkShiftScheduler.Application.Exceptions;

public static class ResourceMessagesException
{
    public const string START_REQUIRED = "A data de início é obrigatória.";
    public const string END_REQUIRED = "A data de fim é obrigatória.";
    public const string START_DATE_GREATER = "A data de início deve ser menor que a data de fim.";
}
