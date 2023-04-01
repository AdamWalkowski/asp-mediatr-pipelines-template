using Example.API.Application.Commands;
using Example.API.Application.Queries;
using Example.API.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Pipelines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;
        private readonly IMediator _mediator;

        public ExampleController(IMediator mediator, ILogger<ExampleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _logger.LogInformation($"{nameof(ExampleController)} constructor called");
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetEntity()
        {
            var query = new ExampleQuery(Guid.NewGuid());

            var entity = await _mediator.Send(query);

            return Ok(entity);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ResponseHeader("Another-Filter-Header", "Another Filter Value")]
        public async Task<IActionResult> PerformAction()
        {
            var command = new ExampleCommand(Guid.NewGuid(), "test name");

            await _mediator.Send(command);

            return Ok(command);
        }
    }
}
