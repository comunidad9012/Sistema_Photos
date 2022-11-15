using ApplicationsServices.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Filters
{
    public class PhotoResponseFilter : ParameterResponse

    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
