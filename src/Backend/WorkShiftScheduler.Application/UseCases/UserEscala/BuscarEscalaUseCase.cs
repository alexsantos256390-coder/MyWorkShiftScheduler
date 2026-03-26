using System.Linq;
using WorkShiftScheduler.Domain.Repositories;

namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class BuscarEscalaUseCase
{
    private readonly IEscalaRepository _repository;

    public BuscarEscalaUseCase(IEscalaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListarEscalasResponse?> Execute(Guid id)
    {
        var escala = await _repository.GetByIdAsync(id);

        if (escala is null)
            return null;

        return new ListarEscalasResponse
        {
            Id = escala.Id,
            Funcionarios = escala.Funcionarios.Select(f => new FuncionarioResponse
            {
                Nome = f.Name,
                Turnos = f.Turnos.Select(t => new TurnoResponse
                {
                    Inicio = t.Inicio,
                    Fim = t.Fim
                }).ToList()
            }).ToList()
        };
    }
}