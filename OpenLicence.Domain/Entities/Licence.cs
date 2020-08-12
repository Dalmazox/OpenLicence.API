using System;

namespace OpenLicence.Domain.Entities
{
    public class Licence
    {
        public Guid ID { get; set; }
        public DateTime Expires { get; set; }
        public Guid EnterpriseID { get; set; }
        public Guid SoftwareID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Enterprise Enterprise { get; set; }
        public virtual Software Software { get; set; }
    }
}