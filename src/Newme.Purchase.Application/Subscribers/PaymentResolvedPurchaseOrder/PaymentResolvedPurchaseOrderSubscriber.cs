using System.Text;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.DependencyInjection;
using Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder.Received;
using Newme.Purchase.Application.Commands.ProcessPurchaseAfterCatalogVerified;
using Newme.Purchase.Domain.Messaging;
using MediatR;

namespace Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder
{
    public class PaymentResolvedPurchaseOrderSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "purchase-service/purchase-order-payment-resolved";
        private const string RoutingKeySubscribe = "purchase-order-payment-resolved";
        private readonly IServiceProvider _serviceProvider;
        private const string TrackingsExchange = "payment-service";
 
        public PaymentResolvedPurchaseOrderSubscriber(IServiceProvider serviceProvider)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
 
            _connection = connectionFactory.CreateConnection("purchase-order-payment-resolved-consumer");
 
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
                var @event = JsonConvert.DeserializeObject<PaymentResolvedPurchaseOrderReceivedEvent>(contentString);
 
                Console.WriteLine($"Message payment resolved purchase order event is received with purchase id: {@event!.PurchaseId}");
 
                Complete(@event).Wait();
 
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
 
            _channel.BasicConsume(Queue, false, consumer);
 
            return Task.CompletedTask;
        }
 
        public async Task Complete(PaymentResolvedPurchaseOrderReceivedEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();

            var messageBus = scope.ServiceProvider.GetRequiredService<IMessageBusServer>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var command = new ProcessPurchaseAfterPaymentVerifiedCommand(@event);
            var response = await mediator.Send(command);
        }
    }
}
