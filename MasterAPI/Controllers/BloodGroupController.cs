using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.BloodGroups.Commands;
using Master.Application.BloodGroups.Queries;
using Master.Application.Countries.Queries;
using Master.Application.Departments.Queries;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodGroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BloodGroupController> _logger;
        public BloodGroupController(IMediator mediator, ILogger<BloodGroupController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetBloodGroup")]
        public async Task<IActionResult> GetBloodGroup([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetBloodGroupQuery { Id= id });
            return Ok(data);
            
        }
        [HttpPost("SaveBloodGroup")]
        public async Task<IActionResult> SaveBloodGroup([FromBody] BloodGroupCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
