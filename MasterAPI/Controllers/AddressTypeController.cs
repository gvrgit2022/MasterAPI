using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Address.Commands;
using Master.Application.Address.Queries;
namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressTypeController> _logger;
        public AddressTypeController(IMediator mediator, ILogger<AddressTypeController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetAddressType")]
        public async Task<IActionResult> GetAddressType([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetAddressTypeQuery { AddressTypeId= id });
            return Ok(data);

        }
        [HttpPost("SaveAddressType")]
        public async Task<IActionResult> SaveAddressType([FromBody] AddressTypeCommand addrCommand)
        {

            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
