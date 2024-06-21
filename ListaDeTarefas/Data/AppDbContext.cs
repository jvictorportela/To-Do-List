using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskTD> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = "trabalho", Name = "Trabalho" },
            new Category { CategoryId = "casa", Name = "Casa" },
            new Category { CategoryId = "faculdade", Name = "Faculdade" },
            new Category { CategoryId = "academia", Name = "Academia" },
            new Category { CategoryId = "contas", Name = "Contas" }
            );

        modelBuilder.Entity<Status>().HasData(
            new Status { StatusId = "aberto", Name = "Aberto"},
            new Status { StatusId = "completo", Name = "Completo"}
            );

        base.OnModelCreating(modelBuilder);
    }
}
