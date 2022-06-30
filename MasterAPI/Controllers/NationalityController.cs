using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Nationalities.Queries;
using Master.Application.Nationalities.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NationalityController> _logger;
        public NationalityController(IMediator mediator, ILogger<NationalityController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetNationality")]
        public async Task<IActionResult> GetNationality([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetNationalityQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveNationality")]
        public async Task<IActionResult> SaveNationality([FromBody] NationalityCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
