using ApplicationsServices.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Filters
{
    public class UserResponseFilter : ParameterResponse

    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
