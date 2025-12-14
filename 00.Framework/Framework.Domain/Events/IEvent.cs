namespace Framework.Domain.Events
{
    public interface IEvent
    {
    }
    public interface IEventPublisher
    {
        void Publish(IEvent eventMessage);
    }
    public interface IEventSubscriber
    {
        void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent;
    }
    public interface IEventBus
    {
        void Publish(IEvent eventMessage);
        void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent;
    }
    public interface IDomainEvent : IEvent
    {
    }
}
