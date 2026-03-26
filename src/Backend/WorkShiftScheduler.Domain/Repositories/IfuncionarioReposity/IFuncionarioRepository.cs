using System.Threading.Tasks;
using WorkShiftScheduler.Domain.Entities;

namespace WorkShiftScheduler.Domain.Repositories.IfuncionarioReposity;

public interface IFuncionarioRepository
{ Task AddAsync(Funcionario funcionario);
    Task UpdateAsync(Funcionario funcionario);
    Task<List<Funcionario>> GetAllAsync();
    Task<Funcionario?> GetByIdAsync(Guid id);


}
