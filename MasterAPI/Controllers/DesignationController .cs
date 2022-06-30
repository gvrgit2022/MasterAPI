using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Countries.Model;
using Master.Application.Countries.Queries;
using Master.Application.BloodGroups.Commands;
using Master.Application.Designations.Queries;
using Master.Application.Designations.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DesignationController> _logger;
        public DesignationController(IMediator mediator, ILogger<DesignationController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetDesignation")]
        public async Task<IActionResult> GetDesignation([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetDesignationQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveDesignation")]
        public async Task<IActionResult> SaveDesignation([FromBody] DesignationCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
