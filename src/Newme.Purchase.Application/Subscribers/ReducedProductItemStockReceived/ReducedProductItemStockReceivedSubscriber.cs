using System.Text;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.DependencyInjection;
using Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Received;
using Newme.Purchase.Domain.Messaging;
using MediatR;
using Newme.Purchase.Application.Commands.ProcessPurchaseAfterCatalogVerified;

namespace Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived
{
    public class ReducedProductItemStockReceivedSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "purchase-service/catalog-reduced-product-stock";
        private const string RoutingKeySubscribe = "catalog-reduced-product-stock";
        private readonly IServiceProvider _serviceProvider;
        private const string TrackingsExchange = "catalog-service";
 
        public ReducedProductItemStockReceivedSubscriber(IServiceProvider serviceProvider)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
 
            _connection = connectionFactory.CreateConnection("catalog-reduced-product-stock-consumer");
 
            _channel = _connection.CreateModel();
 
            _channel.QueueDeclare(
                queue: Queue,
                durable: true,
                exclusive: false,
                autoDelete: false);
 
            _channel.QueueBind(Queue, TrackingsExchange, RoutingKeySubscribe);
 
            _serviceProvider = serviceProvider;
        }
 
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
 
            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var @event = JsonConvert.DeserializeObject<ReducedProductsStockReceivedEvent>(contentString);
 
                Console.WriteLine($"Message catalog reduced product stock event is received with purchase id: {@event!.PurchaseId}");
 
                Complete(@event).Wait();
 
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
 
            _channel.BasicConsume(Queue, false, consumer);
 
            return Task.CompletedTask;
        }
 
        public async Task Complete(ReducedProductsStockReceivedEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();

            var messageBus = scope.ServiceProvider.GetRequiredService<IMessageBusServer>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var command = new ProcessPurchaseAfterCatalogVerifiedCommand(@event);
            var response = await mediator.Send(command);
        }
    }
}
