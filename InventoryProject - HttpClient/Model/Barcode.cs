using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientHttp.Model
{
    class Barcode
    {
        public int Barcodeid { get; set; }

        public int? Deviceid { get; set; }

        public string Barcodevalue { get; set; } = null!;

        public DateTime? Createdat { get; set; }

        public virtual Device? Device { get; set; }
    }
}
