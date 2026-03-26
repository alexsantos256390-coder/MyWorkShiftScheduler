namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class ListarEscalasResponse
{
    public Guid Id { get; set; }

    public List<FuncionarioResponse> Funcionarios { get; set; } = new();
}

public class FuncionarioResponse
{
    public string Nome { get; set; }

    public List<TurnoResponse> Turnos { get; set; } = new();
}

public class TurnoResponse
{
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}