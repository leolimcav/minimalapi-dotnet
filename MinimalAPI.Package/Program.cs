using MinimalApi.Package.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.AddDapper();
builder.AddServices();
builder.AddOpenApi();

var app = builder.Build();
app.UseServices();
app.UseOpenApi();
app.MapCarter();

app.UseHttpsRedirection();

app.Run();
