using ToDoApp.Common;
using ToDoApp.Common.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddControllers();
builder.AddDataContexts();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureEnvironment();

app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
app.Run();
