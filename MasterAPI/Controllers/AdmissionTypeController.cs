using MediatR;
using Microsoft.AspNetCore.Mvc;
using Master.Application.Admission.Commands;
using Master.Application.Admission.Query;
namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressTypeController> _logger;
        public AdmissionTypeController(IMediator mediator, ILogger<AddressTypeController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet("GetAdmissionType")]
        public async Task<IActionResult> GetAdmissionType([FromQuery] int id)
        {
            var data = await _mediator.Send(new GetAdmissionTypeQuery {   });
            return Ok(data);

        }
        [HttpPost("SaveAdmissionType")]
        public async Task<IActionResult> SaveAdmissionType([FromBody] AdmissionTypeCommand addrCommand)
        {

            var response = await _mediator.Send(addrCommand);
            _logger.LogInformation($"Registration completed sucessfully.");
            return Ok(response);

        }
    }
}
