using DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.Entity
{
    public class Client : BaseEntityClass
    {
        public string? NameClient { get; set; }

        public string NameLastClient { get; set; }

        public string? Mobile { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public ICollection<Photographer> Photographers { get; set; }

        

    }
}
