namespace ToDoApp.Common;

public static class AppExtension
{
    public static void ConfigureEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}