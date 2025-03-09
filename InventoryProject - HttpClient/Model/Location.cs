using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientHttp.Model
{
    class Location
    {
        public int Locationid { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? Createdat { get; set; }

        public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
