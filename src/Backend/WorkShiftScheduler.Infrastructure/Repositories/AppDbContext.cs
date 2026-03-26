using Microsoft.EntityFrameworkCore;
using WorkShiftScheduler.Domain.Entities;

namespace WorkShiftScheduler.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Escala> Escalas => Set<Escala>();
        public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
        public DbSet<Turno> Turnos => Set<Turno>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Escala>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Funcionarios)
                      .WithOne()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Name)
                      .IsRequired();

                entity.HasMany(f => f.Turnos)
                      .WithOne()
                      .HasForeignKey(t => t.FuncionarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.FuncionarioId)
                      .IsRequired();

                entity.Property(t => t.Inicio)
                      .IsRequired();

                entity.Property(t => t.Fim)
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}