using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Maritalstatus.Queries;
using Master.Application.Maritalstatus.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaritalstatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MaritalstatusController> _logger;
        public MaritalstatusController(IMediator mediator, ILogger<MaritalstatusController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetMaritalstatus")]
        public async Task<IActionResult> GetMaritalstatus([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetMaritalstatusQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveMaritalstatus")]
        public async Task<IActionResult> SaveMaritalstatus([FromBody] MaritalstatusCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
