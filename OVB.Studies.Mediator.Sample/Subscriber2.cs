using OVB.Studies.Mediator.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVB.Studies.Mediator.Sample;

public class Subscriber2 : ISubscriber<Subject>
{
    public async Task HandlerAsync(Subject subject)
    {
        subject.EscreverNoTerminal("Teste 2");
    }
}
