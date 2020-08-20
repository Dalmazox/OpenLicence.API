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
            => new ObjectResult(Build(statusCode, message ?? "Request with error", data));

        public IActionResult Success(int statusCode = StatusCodes.Status200OK, string message = null, object data = null)
            => new ObjectResult(Build(statusCode, message ?? "Request success", data));

        private Response Build(int statusCode, string message, object data)
            => _builder
                    .WithStatusCode(statusCode)
                    .WithMessage(message)
                    .WithData(data)
                    .Build();
    }
}