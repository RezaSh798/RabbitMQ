using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    // UserName = "test",
    // Password = "test"
};

using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "news",
    durable: true, // Should this queue survive a broker restart?
    exclusive: false, // Should this queue use be limited to its declaring connection? Such a queue will be deleted when its declaring connection closes.
    autoDelete: false, // Should this queue be auto-deleted when its last consumer (if any) unsubscribes?
    arguments: null // Optional; additional queue arguments, e.g. "x-queue-type"
);

while (true)
{
    var message = $"{DateTime.UtcNow} - {Guid.CreateVersion7()}";
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(
        exchange: string.Empty,
        routingKey: "news",
        mandatory: true,
        basicProperties: new BasicProperties { Persistent = true },
        body
    );

    Console.WriteLine($"Sent: {message}");

    await Task.Delay(2000);
}