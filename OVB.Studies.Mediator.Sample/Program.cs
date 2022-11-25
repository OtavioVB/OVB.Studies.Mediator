namespace OVB.Studies.Mediator.Sample;

public static class Program
{
    static async Task Main(string[] args)
    { 
        var notifiableContainerMediator = new NotifiableContainer();
        notifiableContainerMediator.Subscribe<Subject, Subscriber>();
        notifiableContainerMediator.Subscribe<Subject, Subscriber2>();
        await notifiableContainerMediator.PublishAsync(new Subject(), typeof(Subject));
    }
}