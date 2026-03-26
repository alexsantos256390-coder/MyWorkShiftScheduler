
using WorkShiftScheduler.Domain.Repositories;

namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class DeletarEscalaUseCase
{
    private readonly IEscalaRepository _Repository;

    public DeletarEscalaUseCase(IEscalaRepository repository)
    {
        _Repository = repository;
    }
    public async Task Execute(Guid id)
    {
        var escala = await _Repository.GetByIdAsync(id);

        if (escala == null)
            throw new Exception("Escala nao encontrada");

        await _Repository.Remove(escala);

    }

}
