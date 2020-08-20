using OpenLicence.Domain.Interfaces.Builders;
using OpenLicence.Domain.ValueObjects;

namespace OpenLicence.Application.Builders
{
    public class ResponseBuilder : IResponseBuilder
    {
        private Response _response;

        public ResponseBuilder()
        {
            _response = new Response();
        }

        public Response Build()
            => _response;

        public IResponseBuilder WithData(object data)
        {
            _response.Data = data;

            return this;
        }

        public IResponseBuilder WithMessage(string message)
        {
            _response.Message = message;

            return this;
        }

        public IResponseBuilder WithStatusCode(int statusCode)
        {
            if (statusCode <= 0) statusCode = 200;
            _response.StatusCode = statusCode;

            return this;
        }
    }
}