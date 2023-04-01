var builder = WebApplication.CreateBuilder(args);

builder.AddOpenApi();
builder.AddServices();
builder.AddMessages();
builder.Services.AddEfCore(builder.Configuration);

// Add services to the container.
var app = builder.Build();
// app.MapCarter();
app.UseServices();
app.UseApiSwagger();

await app.MigrateDatabase();

app.UseHttpsRedirection();

app.Run();
