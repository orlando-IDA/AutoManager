using Microsoft.EntityFrameworkCore;
using AutoManager.Application.Services;
using AutoManager.Infrastructure;
using AutoManager.Infrastructure.Persistence;

namespace AutoManager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 1. Configurar Banco de Dados
        builder.Services.AddDbContext<AutoManagerContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        // 2. Registrar Repositórios (Injeção de Dependência)
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // app.UseHttpsRedirection(); // Comentado para evitar problemas com portas locais
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}