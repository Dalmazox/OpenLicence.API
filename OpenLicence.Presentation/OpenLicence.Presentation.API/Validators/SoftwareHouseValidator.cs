using FluentValidation;
using OpenLicence.Application.Helpers;
using OpenLicence.Domain.Entities;

namespace OpenLicence.Presentation.API.Validators
{
    public class SoftwareHouseValidator : AbstractValidator<SoftwareHouse>
    {
        public SoftwareHouseValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Name not be null")
                .NotEmpty().WithMessage("Name not be provided");


            RuleFor(x => x.CNPJ)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("CNPJ not be null")
                .NotEmpty().WithMessage("CNPJ not be provided")
                .Length(14).WithMessage("CNPJ must have 14 digits")
                .Must(CNPJHelper.IsValid).WithMessage("CNPJ invalid");
        }
    }
}