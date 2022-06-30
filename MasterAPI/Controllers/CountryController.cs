using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Countries.Model;
using Master.Application.Countries.Queries;
using Master.Application.Countries.Commands;
using Master.Application.Departments.Queries;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CountryController> _logger;
        public CountryController(IMediator mediator, ILogger<CountryController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetCountry")]
        public async Task<IActionResult> GetCountry([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetCountryQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveCountry")]
        public async Task<IActionResult> SaveCountry([FromBody] CountryCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
