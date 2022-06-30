using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Services.Queries;
using Master.Application.Services.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ServiceController> _logger;
        public ServiceController(IMediator mediator, ILogger<ServiceController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetService")]
        public async Task<IActionResult> GetService([FromQuery] int id)
        {
            var data = await _mediator.Send(new ServicQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveService")]
        public async Task<IActionResult> SaveService([FromBody] ServiceCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
