using Microsoft.EntityFrameworkCore;
using WorkShiftScheduler.Domain.Entities;
using WorkShiftScheduler.Domain.Repositories;

namespace WorkShiftScheduler.Infrastructure.Repositories;

public class EscalaRepository : IEscalaRepository
{
    private readonly AppDbContext _context;

    public EscalaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Escala escala)
    {
        await _context.Escalas.AddAsync(escala);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Escala>> GetAllAsync()
    {
        return await _context.Escalas
            .Include(e => e.Funcionarios)
                .ThenInclude(f => f.Turnos)
            .ToListAsync();
    }

    public async Task<Escala?> GetByIdAsync(Guid id)
    {
        return await _context.Escalas
            .Include(e => e.Funcionarios)
                .ThenInclude(f => f.Turnos)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Remove(Escala escala)
    {
        _context.Escalas.Remove(escala);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Escala escala)
    {
        _context.Escalas.Update(escala);
        await _context.SaveChangesAsync();
    }
}