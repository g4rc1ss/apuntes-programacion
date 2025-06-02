using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubSubCommunication.Consumers.Manager;

namespace PubSubCommunication.Consumers.Host;

public class ConsumerController<TMessage>(IConsumerManager<TMessage> consumerManager) : Controller
{
    public readonly IConsumerManager<TMessage> consumerManager = consumerManager;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route("start")]
    public virtual IActionResult Start()
    {
        consumerManager.RestartExecution();
        return Ok();
    }
}
