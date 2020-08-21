using System;
using OpenLicence.Domain.Entities;
using OpenLicence.Domain.Interfaces.Repositories;
using OpenLicence.Domain.Interfaces.Services;
using OpenLicence.Domain.Interfaces.UoW;

namespace OpenLicence.Application.Services
{
    public class SoftwareHouseService : BaseService<SoftwareHouse, ISoftwareHouseRepository>, ISoftwareHouseService
    {
        public SoftwareHouseService(IUnitOfWork uow) : base(uow)
        { }

        public override void Add(SoftwareHouse entity)
        {
            Normalize(entity);

            var exists = _repository.One(sh => sh.CNPJ.Equals(entity.CNPJ)) != null;

            if (exists)
                throw new Exception("CNPJ already registered");

            base.Add(entity);
        }

        public override void Normalize(SoftwareHouse entity)
        {
            entity.Name = entity.Name.Trim().ToUpper();
            entity.CNPJ = entity.CNPJ.Trim();
            entity.CreatedAt = entity.CreatedAt.ToUniversalTime();
            entity.UpdatedAt = entity.UpdatedAt.ToUniversalTime();
        }
    }
}