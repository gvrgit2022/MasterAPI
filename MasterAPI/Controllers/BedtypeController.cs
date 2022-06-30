using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Bedtypes.Queries;
using Master.Application.Bedtypes.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedtypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BedtypeController> _logger;
        public BedtypeController(IMediator mediator, ILogger<BedtypeController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetBedtype")]
        public async Task<IActionResult> GetBedtype([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetBedtypeQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveBedtype")]
        public async Task<IActionResult> SaveBedtype([FromBody] BedtypeCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
