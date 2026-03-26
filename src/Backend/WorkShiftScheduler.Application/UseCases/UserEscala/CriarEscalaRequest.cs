namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class CriarEscalaRequest
{
    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public List<string> NomesFuncionarios { get; set; } = new();
}