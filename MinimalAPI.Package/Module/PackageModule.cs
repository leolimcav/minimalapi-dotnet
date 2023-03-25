using Carter;

namespace MinimalAPI.Package.Module;

public sealed class PackageModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello World");
    }
}
