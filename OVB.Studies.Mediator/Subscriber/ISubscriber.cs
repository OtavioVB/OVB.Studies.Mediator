using System.Runtime.InteropServices.JavaScript;

namespace OVB.Studies.Mediator.Subscriber;

public interface ISubscriber<in TSubject>
{
    public Task HandlerAsync(TSubject subject);
}
