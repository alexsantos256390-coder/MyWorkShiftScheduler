using WorkShiftScheduler.Domain.Repositories;

namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class ListarEscalasUseCase
{
    private readonly IEscalaRepository _repository;

    public ListarEscalasUseCase(IEscalaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ListarEscalasResponse>> Execute()
    {
        var escalas = await _repository.GetAllAsync();

        return escalas.Select(e => new ListarEscalasResponse
        {
            Id = e.Id,
        }).ToList();
    }
}