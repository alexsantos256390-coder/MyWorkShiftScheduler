using System;

namespace WorkShiftScheduler.Domain.Entities;

public class Turno
{
    public Guid Id { get; private set; }
    public Guid FuncionarioId { get; private set; }

    public DateTime Inicio { get; private set; }
    public DateTime Fim { get; private set; }

    private Turno() { }

    public Turno(Guid funcionarioId, DateTime inicio, DateTime fim)
    {
        if (funcionarioId == Guid.Empty)
            throw new ArgumentException("Funcionário inválido.");

        if (inicio >= fim)
            throw new ArgumentException("O horário de início deve ser menor que o horário de fim.");

        ValidarHorarioPermitido(inicio, fim);

        Id = Guid.NewGuid();
        FuncionarioId = funcionarioId;
        Inicio = inicio;
        Fim = fim;
    }

    private void ValidarHorarioPermitido(DateTime inicio, DateTime fim)
    {
        var horaInicio = inicio.TimeOfDay;
        var horaFim = fim.TimeOfDay;

        var turnoManhaInicio = new TimeSpan(10, 0, 0);
        var turnoManhaFim = new TimeSpan(18, 0, 0);

        var turnoTardeInicio = new TimeSpan(15, 0, 0);
        var turnoTardeFim = new TimeSpan(23, 0, 0);

        bool turnoManhaValido =
            horaInicio == turnoManhaInicio &&
            horaFim == turnoManhaFim;

        bool turnoTardeValido =
            horaInicio == turnoTardeInicio &&
            horaFim == turnoTardeFim;

        if (!turnoManhaValido && !turnoTardeValido)
        {
            throw new ArgumentException(
                "Turno inválido. Permitido apenas: 10:00–18:00 ou 15:00–23:00.");
        }
    }

    public double TotalHoras()
    {
        return (Fim - Inicio).TotalHours;
    }
}