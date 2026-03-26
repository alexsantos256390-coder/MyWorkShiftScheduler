using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_WorkShiftScheduler.API.Middlewares;
using WorkShiftScheduler.Application.UseCases.UserEscala;
using WorkShiftScheduler.Domain.Repositories;
using WorkShiftScheduler.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<CriarEscalaUseCase>();
builder.Services.AddScoped<ListarEscalasUseCase>();
builder.Services.AddScoped<BuscarEscalaUseCase>();
builder.Services.AddScoped<DeletarEscalaUseCase>();


builder.Services.AddScoped<IEscalaRepository, EscalaRepository>();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddValidatorsFromAssemblyContaining<CriarEscalaRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();