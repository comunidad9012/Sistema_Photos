using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.Common
{
    public class BaseEntityClass
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public long LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
