using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Countries.Model;
using Master.Application.Countries.Queries;
using Master.Application.Languages.Queries;
using Master.Application.Languages.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LanguageController> _logger;
        public LanguageController(IMediator mediator, ILogger<LanguageController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetLanguage")]
        public async Task<IActionResult> GetLanguage([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetLanguageQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveLanguage")]
        public async Task<IActionResult> SaveLanguage([FromBody] LanguageCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
