using MassTransit;

namespace MinimalAPI.Package.Extensions;

public static partial class ServiceCollectionExtensions 
{
    public static WebApplicationBuilder AddMessages(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(m => 
        {
            m.UsingAzureServiceBus((context, cfg) => 
            {
                cfg.Host(builder.Configuration.GetConnectionString("ServiceBus"));
                cfg.ConfigureEndpoints(context);
            });
        });
 
        return builder;
    }
}
