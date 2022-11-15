using DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.Entity
{
    public class Photo : BaseEntityClass
    {
        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Size { get; set; }

        public string? Quality { get; set; }

        public long Idclient { get; set; }

        public long IdPhotographer { get; set; }

        // aqui es de uno a uno porque solo es con un solo fotografo, no todos 
        public virtual Photographer ?photographers { get; set; }
}
}
