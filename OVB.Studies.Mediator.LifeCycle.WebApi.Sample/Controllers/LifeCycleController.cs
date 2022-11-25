using Microsoft.AspNetCore.Mvc;
using OVB.Studies.Mediator.Container;
using OVB.Studies.Mediator.Sample;

namespace OVB.Studies.Mediator.LifeCycle.WebApi.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifeCycleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] NotifiableContainerBase notifiableContainerMediator)
        {
            notifiableContainerMediator.Subscribe<Subject, Subscriber2>();
            await notifiableContainerMediator.PublishAsync(new Subject(), typeof(Subject));
            return await Task.FromResult(StatusCode(500));
        }
    }
}