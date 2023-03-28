var builder = WebApplication.CreateBuilder(args);

builder.AddOpenApi();
builder.AddServices();
builder.Services.AddEfCore(builder.Configuration);

// Add services to the container.
var app = builder.Build();
app.UseOpenApi();
app.MapCarter();
app.UseServices();

await app.MigrateDatabase();

app.UseHttpsRedirection();

app.Run();
