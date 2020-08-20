using Microsoft.AspNetCore.Mvc;
using OpenLicence.Domain.Interfaces.Helpers;
using OpenLicence.Domain.Interfaces.Services;

namespace OpenLicence.Presentation.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseService _service;
        private readonly IResponseHelper _response;

        public EnterpriseController(
            IEnterpriseService service,
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