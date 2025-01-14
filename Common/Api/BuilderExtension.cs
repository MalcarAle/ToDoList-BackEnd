using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Handlers;
using ToDoApp.Services;

namespace ToDoApp.Common.Api;

public static class BuilderExtension
{
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    }


    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IToDoService, ToDoService>();
    }
}