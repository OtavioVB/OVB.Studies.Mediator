using OVB.Studies.Mediator.Container;
using OVB.Studies.Mediator.Subscriber;

namespace OVB.Studies.Mediator.Sample
{
    public class NotifiableContainer : NotifiableContainerBase
    {
        protected override ISubscriber<TSubject> InstanciateSubscriber<TSubject>(Type subscriberType)
        {
            var instanceCreation = Activator.CreateInstance(subscriberType);

            if (instanceCreation == null)
            {
                throw new InvalidOperationException();
            }

            return (ISubscriber<TSubject>)instanceCreation;
        }
    }
}
