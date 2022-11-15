using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.Users
{
    public class ClientDTO
    
        {
        public long Id { get; set; }
        public string NameClient { get; set; }

            public string NameLastClient { get; set; }

            public string? Mobile { get; set; }

            public string Email { get; set; }

            public string Address { get; set; }



        }
    
}
