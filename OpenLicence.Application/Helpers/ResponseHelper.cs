using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLicence.Domain.Interfaces.Builders;
using OpenLicence.Domain.Interfaces.Helpers;
using OpenLicence.Domain.ValueObjects;

namespace OpenLicence.Application.Helpers
{
    public class ResponseHelper : IResponseHelper
    {
        private readonly IResponseBuilder _builder;

        public ResponseHelper(IResponseBuilder builder)
        {
            _builder = builder;
        }

        public IActionResult Error(int statusCode = StatusCodes.Status400BadRequest, string message = null, object data = null)
            => Build(statusCode, message ?? "Request with error", data);

        public IActionResult Success(int statusCode = StatusCodes.Status200OK, string message = null, object data = null)
            => Build(statusCode, message ?? "Request success", data);

        public IActionResult ValidationError(object data, int statusCode = StatusCodes.Status400BadRequest)
            => Build(statusCode, "Some validation errors ocurred", data);

        private IActionResult Build(int statusCode, string message, object data)
            => new ObjectResult(_builder
                    .WithStatusCode(statusCode)
                    .WithMessage(message)
                    .WithData(data)
                    .Build())
            { StatusCode = statusCode };
    }
}