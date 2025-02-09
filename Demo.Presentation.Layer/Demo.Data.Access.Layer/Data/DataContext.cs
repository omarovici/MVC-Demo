using Demo.Data.Access.Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Access.Layer.Data;

public class DataContext : DbContext
{
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("ConnectionString");
    // }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(e=>e.Salary)
            .HasColumnType("decimal(18,5)");
    }
}