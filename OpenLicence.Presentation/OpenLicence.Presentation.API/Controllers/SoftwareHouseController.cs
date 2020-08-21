using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Helpers;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Presentation.API.Helpers;
using OpenLicence.Presentation.API.ViewModels;

namespace OpenLicence.Presentation.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class SoftwareHouseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IResponseHelper _response;
        private readonly ISoftwareHouseService _service;
        private readonly IValidator<SoftwareHouse> _validator;

        public SoftwareHouseController(
            IMapper mapper,
            IResponseHelper response,
            ISoftwareHouseService service,
            IValidator<SoftwareHouse> validator)
        {
            _mapper = mapper;
            _service = service;
            _response = response;
            _validator = validator;
        }

        public IActionResult List()
        {
            return _response.Success(data: _mapper.Map<IEnumerable<SoftwareHouseReturnViewModel>>(_service.Get()));
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] SoftwareHouse house)
        {
            try
            {
                var validation = await _validator.ValidateAsync(house);
                if (!validation.IsValid)
                    return _response.ValidationError(ValidationHelper.BeautifyReturn(validation));

                _service.Add(house);

                return _response.Success(statusCode: 201, data: _mapper.Map<SoftwareHouseReturnViewModel>(house));
            }
            catch (Exception ex)
            {
                return _response.Error(message: ex.Message, data: ex.InnerException?.Message);
            }
        }
    }
}