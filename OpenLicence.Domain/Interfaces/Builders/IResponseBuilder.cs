using OpenLicence.Domain.ValueObjects;

namespace OpenLicence.Domain.Interfaces.Builders
{
    public interface IResponseBuilder
    {
        IResponseBuilder WithStatusCode(int statusCode);
        IResponseBuilder WithMessage(string message);
        IResponseBuilder WithData(object data);
        Response Build();
    }
}