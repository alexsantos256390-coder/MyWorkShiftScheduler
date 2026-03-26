namespace WorkShiftScheduler.Domain.Entities;

public class Funcionario
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    private readonly List<Turno> _turnos = new();

    public IReadOnlyCollection<Turno> Turnos => _turnos.AsReadOnly();

    private Funcionario() { }

    public Funcionario(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome do funcionário é obrigatório.");

        Id = Guid.NewGuid();
        Name = name;
    }

    public void AssumirTurno(Turno turno)
    {
        if (turno is null)
            throw new ArgumentNullException(nameof(turno));

        _turnos.Add(turno);
    }
}