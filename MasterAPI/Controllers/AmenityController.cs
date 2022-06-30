using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Amenities.Queries;
using Master.Application.Amenities.Commands;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AmenityController> _logger;
        public AmenityController(IMediator mediator, ILogger<AmenityController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetAmenity")]
        public async Task<IActionResult> GetAmenity([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetAmenitiesQuery { Id= id });
            return Ok(data);

        }
        [HttpPost("SaveAmenity")]
        public async Task<IActionResult> SaveAmenity([FromBody] AmenityCommand addrCommand)

        {
            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
