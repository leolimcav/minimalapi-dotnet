using Microsoft.OpenApi.Models;

namespace MinimalAPI.Delivery.Extensions;

public static partial class ServiceColletionExtensions 
{
    public static WebApplicationBuilder AddOpenApi(this WebApplicationBuilder builder) 
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
                    {
                       Description = "MAPI - Delivery",
                       Title = "MAPI - Delivery",
                       Version = "v1",
                       Contact = new OpenApiContact 
                       {
                            Name = "Developers",
                            Email = "teste@devs.com",
                       }
                    });
        });

        return builder;
    }

    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => 
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
        });

        return app;
    }
}
