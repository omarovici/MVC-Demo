using System.Reflection;
using Business.Logic.Layer.Interfaces;
using Business.Logic.Layer.Repositories;
using Demo.Data.Access.Layer.Data;
using Demo.Data.Access.Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Presentation.Layer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        // builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // builder.Services.AddScoped<IGenaricRepository<Department>, GenaricRepository<Department>>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}