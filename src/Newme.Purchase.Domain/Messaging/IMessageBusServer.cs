namespace Newme.Purchase.Domain.Messaging
{
    public interface IMessageBusServer
    {
        void Publish(object data, string routingKey);
    }
}