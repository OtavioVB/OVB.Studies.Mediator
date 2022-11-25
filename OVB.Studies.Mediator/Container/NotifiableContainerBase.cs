using OVB.Studies.Mediator.Subscriber;

namespace OVB.Studies.Mediator.Container;

public abstract class NotifiableContainerBase
{
    public Dictionary<Type, List<Type>> SubscriptionDictionary { get; private set; }

    protected NotifiableContainerBase()
    {
        SubscriptionDictionary = new Dictionary<Type,List<Type>>();
    }

    private void AddSubjectTypeWhenNotExists(Type subjectType)
    {
        if (SubscriptionDictionary.ContainsKey(subjectType)) return;

        SubscriptionDictionary.Add(subjectType, new List<Type>());
    }

    private void AddSubscriber(Type subjectType, Type subscriberType)
    {
        AddSubjectTypeWhenNotExists(subjectType);

        if (SubscriptionDictionary[subjectType].Any(p => p == subscriberType)) return;

        SubscriptionDictionary[subjectType].Add(subscriberType);
    }

    private List<Type> GetSubscriberTypeCollection(Type subjectType)
    {
        if (!SubscriptionDictionary.ContainsKey(subjectType))
            return new();

        return SubscriptionDictionary[subjectType];
    }

    protected abstract ISubscriber<TSubject> InstanciateSubscriber<TSubject>(Type subscriberType);

    public void Subscribe(Type subjectType, Type subscriber)
    {
        AddSubscriber(subjectType, subscriber);
    }

    public void Subscribe<TSubscriber>(Type subjectType)
    {
        AddSubscriber(subjectType, typeof(TSubscriber));
    }

    public void Subscribe<TSubjectType, TSubscriber>()
    {
        AddSubscriber(typeof(TSubjectType), typeof(TSubscriber));
    }

    public async Task PublishAsync<TSubject>(TSubject subject, Type subjectBaseType)
    {
        var subscriberTypeCollection = GetSubscriberTypeCollection(subjectBaseType);

        foreach (var subscriberType in subscriberTypeCollection)
            await InstanciateSubscriber<TSubject>(subscriberType).HandlerAsync(subject).ConfigureAwait(false);
    }
}
