using WorkShiftScheduler.Domain.Entities;

namespace WorkShiftScheduler.Domain.Repositories;

public interface IEscalaRepository
{
    Task AddAsync(Escala escala);

    Task<List<Escala>> GetAllAsync();

    Task<Escala?> GetByIdAsync(Guid id);

    Task Remove(Escala escala);
}