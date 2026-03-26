using Microsoft.EntityFrameworkCore;
using WorkShiftScheduler.Domain.Entities;
using WorkShiftScheduler.Domain.Repositories.IfuncionarioReposity;

namespace WorkShiftScheduler.Infrastructure.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;

    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Funcionario>> GetAllAsync()
    {
        return await _context.Funcionarios
            .Include(f => f.Turnos)
            .ToListAsync();
    }

    public async Task<Funcionario?> GetByIdAsync(Guid id)
    {
        return await _context.Funcionarios
            .Include(f => f.Turnos)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task UpdateAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
    }
}