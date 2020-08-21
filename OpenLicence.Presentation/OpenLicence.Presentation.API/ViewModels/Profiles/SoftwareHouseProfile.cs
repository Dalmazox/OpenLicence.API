using AutoMapper;
using OpenLicence.Domain.Entities;

namespace OpenLicence.Presentation.API.ViewModels.Profiles
{
    public class SoftwareHouseProfile : Profile
    {
        public SoftwareHouseProfile()
        {
            CreateMap<SoftwareHouse, SoftwareHouseReturnViewModel>();
        }
    }
}