using MassTransit;
using MinimalAPI.Delivery.Consumer;

namespace MinimalAPI.Delivery.Extensions;

public static partial class ServiceCollectionExtensions 
{
    public static WebApplicationBuilder AddMessages(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(m => 
        {
           m.AddConsumer<PackageCreatedConsumer>();

           m.AddBus(provider => AzureBusFactory.CreateUsingServiceBus(cfg =>
           {
                cfg.Host(builder.Configuration.GetConnectionString("ServiceBus"), h =>
                {
                    h.RetryLimit = 3;
                });

                cfg.ReceiveEndpoint("subs-packagecreated", c => 
                {
                    c.EnablePartitioning = true;
                    c.UseMessageRetry(r => r.Interval(5, 1000));
                    c.ConfigureConsumer<PackageCreatedConsumer>(provider);
                });
           }));
        });
 
        return builder;
    }
}
