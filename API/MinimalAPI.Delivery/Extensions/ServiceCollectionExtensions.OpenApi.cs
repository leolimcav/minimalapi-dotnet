using FastEndpoints.Swagger;

namespace MinimalAPI.Delivery.Extensions;

public static partial class ServiceColletionExtensions 
{
    public static WebApplicationBuilder AddOpenApi(this WebApplicationBuilder builder) 
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDoc(c => 
        {
            c.Title = "MAPI - Delivery";
            c.Description = "MAPI - Delivery";
            c.Version = "v1";
        });

        return builder;
    }

  [Obsolete]
  public static IApplicationBuilder UseApiSwagger(this IApplicationBuilder app)
    {
        app.UseSwaggerGen();
        return app;
    }
}
