using System;
using System.Collections.Generic;

namespace OpenLicence.Domain.Entities
{
    public class Software
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid SoftwareHouseID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual SoftwareHouse SoftwareHouse { get; set; }
        public virtual ICollection<Licence> Licences { get; set; }
    }
}