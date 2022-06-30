using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Religions.Queries;
using Master.Application.Religions.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReligionController> _logger;
        public ReligionController(IMediator mediator, ILogger<ReligionController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetReligion")]
        public async Task<IActionResult> GetReligion([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetReligionQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveReligion")]
        public async Task<IActionResult> SaveReligion([FromBody] ReligionCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
