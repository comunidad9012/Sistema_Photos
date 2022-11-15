using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.Users
{
   public class EventsDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }

        public string Service { get; set; }

        public DateTime date { get; set; } 

    }
}
