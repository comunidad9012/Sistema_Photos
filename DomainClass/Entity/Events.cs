using DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.Entity
{
    public class Events : BaseEntityClass

    {
        public string Type { get; set; }
        public string Service { get; set; }
        public DateTime? Date { get; set; }
        public ICollection <Photographer> Photographers { get; set; }


    }
}
