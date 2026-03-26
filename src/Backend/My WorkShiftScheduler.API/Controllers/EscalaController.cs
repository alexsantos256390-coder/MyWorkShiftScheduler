using Microsoft.AspNetCore.Mvc;
using WorkShiftScheduler.Application.UseCases.UserEscala;

namespace My_WorkShiftScheduler.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EscalaController : ControllerBase
{
    private readonly CriarEscalaUseCase _criarEscalaUseCase;
    private readonly ListarEscalasUseCase _listarEscalasUseCase;
    private readonly BuscarEscalaUseCase _buscarEscalaUseCase;
    private readonly DeletarEscalaUseCase _deletarEscalaUseCase;

    public EscalaController(
        CriarEscalaUseCase criarEscalaUseCase,
        ListarEscalasUseCase listarEscalasUseCase,
        BuscarEscalaUseCase buscarEscalaUseCase,
        DeletarEscalaUseCase deletarEscalaUseCase)

    {
        _criarEscalaUseCase = criarEscalaUseCase;
        _listarEscalasUseCase = listarEscalasUseCase;
        _buscarEscalaUseCase = buscarEscalaUseCase;
        _deletarEscalaUseCase = deletarEscalaUseCase;
        
    }

    [HttpPost]
    public async Task<IActionResult> CriarEscala([FromBody] CriarEscalaRequest request)
    {
        var response = await _criarEscalaUseCase.Execute(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = response.EscalaId },
            response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var escalas = await _listarEscalasUseCase.Execute();
        return Ok(escalas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var escala = await _buscarEscalaUseCase.Execute(id);

        if (escala is null)
            return NotFound(new { message = "Escala não encontrada." });

        return Ok(escala);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deletarEscalaUseCase.Execute(id);
        return NoContent();
    }
}