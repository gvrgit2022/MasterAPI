using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Countries.Model;
using Master.Application.Countries.Queries;
using Master.Application.Genders.Queries;
using Master.Application.Genders.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GenderController> _logger;
        public GenderController(IMediator mediator, ILogger<GenderController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetGender")]
        public async Task<IActionResult> GetGender([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetGenderQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveGender")]
        public async Task<IActionResult> SaveGender([FromBody] GenderCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
