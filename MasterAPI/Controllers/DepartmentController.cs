using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Countries.Model;
using Master.Application.Countries.Queries;
using Master.Application.Departments.Commands;
using Master.Application.Departments.Queries;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IMediator mediator, ILogger<DepartmentController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetDepartment")]
        public async Task<IActionResult> GetDepartment([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetDepartmentQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveDepartment")]
        public async Task<IActionResult> SaveDepartment([FromBody] DepartmentCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
