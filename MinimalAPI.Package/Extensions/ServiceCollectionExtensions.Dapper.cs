using Npgsql;

namespace MinimalAPI.Package.Extensions;

public static partial class ServiceColletionExtensions
{
    public static WebApplicationBuilder AddDapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(_ => new NpgsqlConnection(builder.Configuration.GetConnectionString("DbConn")));

        return builder;
    }
}
