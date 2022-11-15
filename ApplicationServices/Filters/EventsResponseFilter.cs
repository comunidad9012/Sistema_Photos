using ApplicationsServices.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Filters
{
    public class EventsResponseFilter : ParameterResponse

    {
        public string? Type { get; set; }
        public string? Service { get; set; }
        public bool IsDeleted { get; set; }
    }
}
