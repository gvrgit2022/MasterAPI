using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.CityAreas.Queries;
using Master.Application.CityAreas.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityAreaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CityAreaController> _logger;
        public CityAreaController(IMediator mediator, ILogger<CityAreaController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetCityArea")]
        public async Task<IActionResult> GetCityArea([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetCityAreaQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveCityArea")]
        public async Task<IActionResult> SaveCityArea([FromBody] CityAreaCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
