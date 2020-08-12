using System;
using System.Collections.Generic;

namespace OpenLicence.Domain.Entities
{
    public class Enterprise
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Licence> Licences { get; set; }
    }
}