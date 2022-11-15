using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.Users
{
    public class PhotoDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? size { get; set; }

        public string? Quality { get; set; }

        public long Idclient { get; set; }

        public long IdPhotographer { get; set; }
    }
}
