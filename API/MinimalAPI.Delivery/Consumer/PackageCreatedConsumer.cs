using MassTransit;
using MinimalAPI.Contracts;

namespace MinimalAPI.Delivery.Consumer;

public sealed class PackageCreatedConsumer : IConsumer<PackageCreated>
{
    private readonly DeliveryDbContext _db;
    private readonly ILogger<PackageCreatedConsumer> _logger;

    public PackageCreatedConsumer(DeliveryDbContext db, ILogger<PackageCreatedConsumer> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<PackageCreated> context)
    {
        _logger.LogInformation($"Message Received : {context.Message}");
        _db.Add(new Package(context.Message.PackageId, context.Message.Code));
        await _db.SaveChangesAsync();
    }
}
