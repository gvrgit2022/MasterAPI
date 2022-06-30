using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Age.Commands;
using Master.Application.Age.Queries;
namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AgeTypeController> _logger;
        public AgeTypeController(IMediator mediator, ILogger<AgeTypeController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetAgeType")]
        public async Task<IActionResult> GetAgeType([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetAgeTypeQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveAgeType")]
        public async Task<IActionResult> SaveAgeType([FromBody] AgeTypeCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
