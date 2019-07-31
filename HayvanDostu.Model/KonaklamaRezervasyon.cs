using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Model
{
    public class KonaklamaRezervasyon : Rezervasyon
    {
        public DateTime BitisTarihi { get; set; }
        public int Adet { get; set; }
        public int OdemeID { get; set; }
        public int HayvanTuruID { get; set; }

        // Mapping
        public virtual HayvanTuru HayvanTuru { get; set; }
        public virtual Odeme Odeme { get; set; }

    }
}
