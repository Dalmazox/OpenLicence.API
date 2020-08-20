using Microsoft.AspNetCore.Mvc;
using OpenLicence.Domain.Interfaces.Helpers;
using OpenLicence.Domain.Interfaces.Services;

namespace OpenLicence.Presentation.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class SoftwareHouseController : ControllerBase
    {
        private readonly ISoftwareHouseService _service;
        private readonly IResponseHelper _response;

        public SoftwareHouseController(
            ISoftwareHouseService service,
            IResponseHelper response)
        {
            _service = service;
            _response = response;
        }

        public IActionResult List()
        {
            return _response.Success(data: _service.Get());
        }
    }
}