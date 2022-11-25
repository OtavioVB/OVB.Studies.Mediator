using OVB.Studies.Mediator.Subscriber;

namespace OVB.Studies.Mediator.Sample;

public class Subscriber : ISubscriber<Subject>
{
    public async Task HandlerAsync(Subject subject)
    {
        subject.EscreverNoTerminal("Teste");
    }
}
