using CBSD.Seller.Core.Domain.SellerAgg.Events;
using Framework.Domain.Events;

namespace ServiceBusMessaging
{


    // Azure Service Bus Event Publisher Implementation
    public class AzureServiceBusEventPublisher : IEventPublisher
    {
        SellerSentReceiptEvent _orderPlacedEvent;
        public AzureServiceBusEventPublisher()
        {
            
        }
        public void Publish(SellerSentReceiptEvent orderPlacedEvent)
        {
            // Logic to publish the event to Azure Service Bus
            // Example: using Azure.Messaging.ServiceBus;
            // The implementation details would involve sending the event to a Service Bus topic or queue

        }

        public void Publish(IEvent orderPlacedEvent)
        {
            //_orderPlacedEvent=orderPlacedEvent;
            throw new NotImplementedException();
        }
    }
}