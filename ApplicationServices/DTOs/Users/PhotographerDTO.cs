using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.Users
{
    public class PhotographerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string QualityPhoto { get; set; }

        public string SizePhoto { get; set; }

        public long ClientId { get; set; }

        //public long EnventId { get; set; }
        //public long PhotoId { get; set; }

    }
}
