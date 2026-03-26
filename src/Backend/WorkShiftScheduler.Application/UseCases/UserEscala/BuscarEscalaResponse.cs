namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class BuscarEscalaResponse
{
    public Guid Id { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public int TotalTurnos { get; set; }


}
