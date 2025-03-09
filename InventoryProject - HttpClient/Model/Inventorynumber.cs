using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientHttp.Model
{
    class Inventorynumber
    {
        public int Inventorynumberid { get; set; }

        public int? Deviceid { get; set; }

        public string Number { get; set; } = null!;

        public DateTime? Createdat { get; set; }

        public virtual Device? Device { get; set; }
    }
}
