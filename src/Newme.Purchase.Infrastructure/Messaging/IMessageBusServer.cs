namespace Newme.Purchase.Infrastructure.Messaging
{
    public interface IMessageBusServer
    {
        void Publish(object data, string routingKey);
    }
}