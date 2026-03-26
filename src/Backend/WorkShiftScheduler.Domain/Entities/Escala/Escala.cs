namespace WorkShiftScheduler.Domain.Entities;

public class Escala
{
    public Guid Id { get; private set; }

    private readonly List<Funcionario> _funcionarios = new();

    public IReadOnlyCollection<Funcionario> Funcionarios => _funcionarios.AsReadOnly();

    public Escala()
    {
        Id = Guid.NewGuid();
    }

    public void AdicionarFuncionario(Funcionario funcionario)
    {
        if (funcionario is null)
            throw new ArgumentNullException(nameof(funcionario));

        _funcionarios.Add(funcionario);
    }
   
}