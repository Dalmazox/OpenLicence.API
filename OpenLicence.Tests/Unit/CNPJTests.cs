using OpenLicence.Application.Helpers;
using Xunit;

namespace OpenLicence.Tests.Unit
{
    public class CNPJTests
    {
        [Fact]
        public void IsValidCNPJ()
        {
            var cnpj = "11.222.333/0001-81";

            Assert.True(CNPJHelper.IsValid(cnpj));
        }

        [Fact]
        public void IsInvalidCNPJ()
        {
            var cnpj = "06829469000115";

            Assert.False(CNPJHelper.IsValid(cnpj));
        }
    }
}