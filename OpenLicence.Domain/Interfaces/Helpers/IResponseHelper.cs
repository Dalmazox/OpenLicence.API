using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenLicence.Domain.Interfaces.Helpers
{
    public interface IResponseHelper
    {
        IActionResult Error(int statusCode = StatusCodes.Status400BadRequest, string message = null, object data = null);
        IActionResult Success(int statusCode = StatusCodes.Status200OK, string message = null, object data = null);
        IActionResult ValidationError(object data, int statusCode = StatusCodes.Status400BadRequest);
    }
}