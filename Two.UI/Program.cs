using Two.DependencyInjection;
using Two.UI.Configurations;
using Two.UI.Controllers.Middlewares.ErrorHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddDefaultApplicationConfiguration(builder.Environment.IsDevelopment());

builder.Services.AddControllers();

builder.Services.AddOpenAPI();

var app = builder.Build();

app.UseOpenAPI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddErrorHandlers(app.Environment);

app.Run();
