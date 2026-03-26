using FluentValidation;
using WorkShiftScheduler.Domain.Entities;
using WorkShiftScheduler.Domain.Repositories;
using AppValidationException = WorkShiftScheduler.Application.Exceptions.RequestValidationException;

namespace WorkShiftScheduler.Application.UseCases.UserEscala;

public class CriarEscalaUseCase
{
    private readonly IEscalaRepository _escalaRepository;
    private readonly IValidator<CriarEscalaRequest> _validator;

    public CriarEscalaUseCase(
        IEscalaRepository escalaRepository,
        IValidator<CriarEscalaRequest> validator)
    {
        _escalaRepository = escalaRepository;
        _validator = validator;
    }

    public async Task<CriarEscalaResponse> Execute(CriarEscalaRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new AppValidationException(
                validationResult.Errors.Select(e => e.ErrorMessage)
            );
        }

        var escala = new Escala();

        var random = new Random();

        foreach (var nome in request.NomesFuncionarios)
        {
            var funcionario = new Funcionario(nome);

            bool turnoManha = random.Next(0, 2) == 0;

            var dataTurno = request.DataInicio;

            DateTime inicio;
            DateTime fim;

            if (turnoManha)
            {
                inicio = dataTurno.AddHours(10);
                fim = dataTurno.AddHours(18);
            }
            else
            {
                inicio = dataTurno.AddHours(15);
                fim = dataTurno.AddHours(23);
            }

            var turno = new Turno(funcionario.Id, inicio, fim);

            funcionario.AssumirTurno(turno);

            escala.AdicionarFuncionario(funcionario);
        }

        await _escalaRepository.AddAsync(escala);

        return new CriarEscalaResponse
        {
            EscalaId = escala.Id
        };
    }
}