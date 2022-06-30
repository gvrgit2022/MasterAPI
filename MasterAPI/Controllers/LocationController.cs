using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Locations.Queries;
using Master.Application.Locations.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LocationController> _logger;
        public LocationController(IMediator mediator, ILogger<LocationController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetLocation")]
        public async Task<IActionResult> GetLocation([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetLocationQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveLocation")]
        public async Task<IActionResult> SaveLocation([FromBody] LocationCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
